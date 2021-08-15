﻿using CommonAlertingServer.Models.Alerts.Dwd;
using CommonAlertingServer.Services.Alerts.Dwd.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace CommonAlertingServer.Services.Alerts.Dwd
{
    public class DwdAlertService : IDwdAlertService
    {
        private readonly ILogger<DwdAlertService> _logger;
        private readonly XNamespace dwdNamespace;
        private readonly XNamespace wfsNamespace;
        private readonly XmlSerializer dwdAlertSerializer;

        public DwdAlertService(ILogger<DwdAlertService> logger)
        {
            _logger = logger;
            dwdNamespace = "http://www.dwd.de";
            wfsNamespace = "http://www.opengis.net/wfs/2.0";
            dwdAlertSerializer = new XmlSerializer(typeof(DwdAlert));
        }

        public List<DwdAlert> GetAlerts(int limit, int page)
        {
            var getResultList = new List<DwdAlert>();

            XDocument xDocument = XDocument.Load("https://maps.dwd.de/geoserver/dwd/ows?service=WFS&request=GetFeature&typeName=dwd:Warnungen_Gemeinden");

            var queryResult = xDocument.Descendants(dwdNamespace + "Warnungen_Gemeinden").Skip(page * limit - limit).Take(limit);

            foreach (var result in queryResult)
            {
                getResultList.Add((DwdAlert)dwdAlertSerializer.Deserialize(result.CreateReader()));
            }

            _logger.LogDebug("Retrieving all alerts");

            return getResultList;
        }

        public List<DwdAlert> GetAlertsFor(string warncellId, int limit, int page)
        {
            var getResultList = new List<DwdAlert>();

            _logger.LogDebug($"Retrieving all alerts for {warncellId}");

            XDocument xDocument = XDocument.Load("https://maps.dwd.de/geoserver/dwd/ows?service=WFS&request=GetFeature&typeName=dwd:Warnungen_Gemeinden");

            var queryResult = xDocument.Descendants(dwdNamespace + "Warnungen_Gemeinden").Where(p => p.Descendants(dwdNamespace + "WARNCELLID").FirstOrDefault().Value.Contains(warncellId)) .Skip(page * limit - limit).Take(limit);

            foreach (var result in queryResult)
            {
                getResultList.Add((DwdAlert)dwdAlertSerializer.Deserialize(result.CreateReader()));
            }

            _logger.LogDebug("Retrieving all alerts");

            return getResultList;
        }
    }
}
