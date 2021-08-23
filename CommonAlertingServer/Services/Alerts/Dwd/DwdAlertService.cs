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
    public class DwdAlertService : IDwdAlertService
    {
        private readonly ILogger<DwdAlertService> _logger;
        private readonly IDwdAlertCacheService _dwdAlertCacheService;
        private readonly XNamespace dwdNamespace;
        private readonly XNamespace wfsNamespace;
        private readonly XmlSerializer dwdAlertSerializer;

        public DwdAlertService(ILogger<DwdAlertService> logger, IDwdAlertCacheService dwdAlertCacheService)
        {
            _logger = logger;
            _dwdAlertCacheService = dwdAlertCacheService;
            dwdNamespace = "http://www.dwd.de";
            wfsNamespace = "http://www.opengis.net/wfs/2.0";
            dwdAlertSerializer = new XmlSerializer(typeof(DwdAlert));
        }

        public IList<DwdAlert> GetAlerts(int limit, int page)
        {
            IReadOnlyList<DwdAlert> resultAlerts = _dwdAlertCacheService.GetDwdAlerts();

            return resultAlerts.Skip(page * limit - limit).Take(limit).ToList();
        }

        public List<DwdAlert> GetAlertsFor(string warncellId, int limit, int page)
        {
            var getResultList = new List<DwdAlert>();

            _logger.LogDebug($"Retrieving all alerts for {warncellId}");

            IReadOnlyList<DwdAlert> resultAlerts = _dwdAlertCacheService.GetDwdAlerts();

            foreach (var result in resultAlerts.Where(p => p.WarnCellId.Contains(warncellId)).Skip(page * limit - limit).Take(limit).AsEnumerable())
            {
                getResultList.Add(result);
            }

            _logger.LogDebug("Retrieving all alerts");

            return getResultList;
        }
    }
}
