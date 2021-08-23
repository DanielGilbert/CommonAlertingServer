using CommonAlertingServer.Models.Alerts.Dwd;
using CommonAlertingServer.Services.Alerts.Dwd.Interfaces;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace CommonAlertingServer.Services.Alerts.Dwd
{
    public class DwdAlertCacheService : IDwdAlertCacheService, IHostedService, IDisposable
    {
        private readonly List<DwdAlert> _dwdAlerts;
        private readonly ILogger<DwdAlertCacheService> _logger;
        private readonly XmlSerializer dwdAlertSerializer;
        private readonly XNamespace dwdNamespace;
        private readonly XNamespace wfsNamespace;
        private Timer _timer;
        private int executionCount = 0;


        public DwdAlertCacheService(ILogger<DwdAlertCacheService> logger)
        {
            _logger = logger;
            dwdNamespace = "http://www.dwd.de";
            wfsNamespace = "http://www.opengis.net/wfs/2.0";
            dwdAlertSerializer = new XmlSerializer(typeof(DwdAlert));
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public IReadOnlyList<DwdAlert> GetDwdAlerts()
        {
            IReadOnlyList<DwdAlert> readonlyDwdAlert = new List<DwdAlert>();

            if (Monitor.TryEnter(_dwdAlerts, TimeSpan.FromMinutes(1)))
            {
                try
                {
                    readonlyDwdAlert = _dwdAlerts.AsReadOnly();
                }
                finally
                {
                    Monitor.Exit(_dwdAlerts);
                }
            }
            else
            {
                _logger.LogError("Could not lock DwdAlert list");
            }

            return readonlyDwdAlert;
        }

        private void FetchDwdData(object state)
        {
            XDocument xDocument = XDocument.Load("https://maps.dwd.de/geoserver/dwd/ows?service=WFS&request=GetFeature&typeName=dwd:Warnungen_Gemeinden");

            var queryResult = xDocument.Descendants(dwdNamespace + "Warnungen_Gemeinden");

            if (Monitor.TryEnter(_dwdAlerts, TimeSpan.FromMinutes(1)))
            {
                try
                {
                    _dwdAlerts.Clear();

                    foreach (var result in queryResult)
                    {
                        try
                        {
                            _dwdAlerts.Add((DwdAlert)dwdAlertSerializer.Deserialize(result.CreateReader()));
                        }
                        catch(Exception ex)
                        {
                            _logger.LogError("Failed to add alert");
                        }
                    }
                }
                finally
                {
                    Monitor.Exit(_dwdAlerts);
                }
            }
            else
            {
                _logger.LogError("Could not lock DwdAlert list");
            }
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Timed Hosted Service running.");

            _timer = new Timer(FetchDwdData, null, TimeSpan.Zero, TimeSpan.FromMinutes(10));

            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
