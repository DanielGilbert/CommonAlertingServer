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
    public class DwdAlertCacheService : IDwdAlertCacheService
    {
        private readonly List<DwdAlert> _dwdAlerts;
        private readonly ILogger<DwdAlertCacheService> _logger;
        private readonly XmlSerializer dwdAlertSerializer;
        private readonly XNamespace dwdNamespace;
        private Timer _timer;


        public DwdAlertCacheService(ILogger<DwdAlertCacheService> logger)
        {
            _dwdAlerts = new List<DwdAlert>();
            _logger = logger;
            dwdNamespace = "http://www.dwd.de";
            dwdAlertSerializer = new XmlSerializer(typeof(DwdAlert));
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
            _logger.LogInformation("Fetching Alerts...");

            try
            {
                XDocument xDocument = XDocument.Load("https://maps.dwd.de/geoserver/dwd/ows?service=WFS&request=GetFeature&typeName=dwd:Warnungen_Gemeinden");

                var queryResult = xDocument.Descendants(dwdNamespace + "Warnungen_Gemeinden");

                if (Monitor.TryEnter(_dwdAlerts, TimeSpan.FromMinutes(1)))
                {
                    try
                    {
                        _dwdAlerts.Clear();

                        _logger.LogInformation($"Got {queryResult.Count()} alert(s)...");

                        foreach (var result in queryResult)
                        {
                            try
                            {
                                _dwdAlerts.Add((DwdAlert)dwdAlertSerializer.Deserialize(result.CreateReader()));
                            }
                            catch (Exception ex)
                            {
                                _logger.LogError(ex, "Failed to add alert");
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
            catch(Exception ex)
            {
                _logger.LogError($"Failed to fetch alerts! Error: {ex}");

            }
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Started DwdAlertCacheService.");

            _timer = new Timer(FetchDwdData, null, TimeSpan.Zero, TimeSpan.FromMinutes(5));

            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _timer.Change(TimeSpan.Zero, TimeSpan.Zero);

            return Task.CompletedTask;
        }
    }
}
