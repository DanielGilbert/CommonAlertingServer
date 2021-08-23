using CommonAlertingServer.Models.Alerts.Dwd;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommonAlertingServer.Services.Alerts.Dwd.Interfaces
{
    public interface IDwdAlertService
    {
        /// <summary>
        /// Will return all available alerts
        /// </summary>
        /// <returns>A list of all alerts</returns>
        IList<DwdAlert> GetAlerts(int limit, int page);
        /// <summary>
        /// Gets all alerts for a given warncellId
        /// </summary>
        /// <param name="warncellId">The warncellid in question</param>
        /// <returns>A list of all corresponding alerts</returns>
        List<DwdAlert> GetAlertsFor(string warncellId, int limit, int page);
    }
}
