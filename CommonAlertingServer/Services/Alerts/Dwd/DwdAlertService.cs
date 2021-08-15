using CommonAlertingServer.Models.Alerts.Dwd;
using CommonAlertingServer.Services.Alerts.Dwd.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CommonAlertingServer.Services.Alerts.Dwd
{
    public class DwdAlertService : IDwdAlertService
    {
        private readonly ILogger<DwdAlertService> _logger;

        public DwdAlertService(ILogger<DwdAlertService> logger)
        {
            _logger = logger;
        }

        public List<DwdAlert> GetAlerts()
        {
            var result = new List<DwdAlert>();

            XDocument xDocument = XDocument.Load("https://maps.dwd.de/geoserver/dwd/ows?service=WFS&request=GetFeature&typeName=dwd:Warnungen_Gemeinden");

            _logger.LogDebug("Retrieving all alerts");

            return result;
        }

        public List<DwdAlert> GetAlertsFor(string warncellId)
        {
            var result = new List<DwdAlert>();

            _logger.LogDebug($"Retrieving all alerts for {warncellId}");

            return result;
        }
    }
}
