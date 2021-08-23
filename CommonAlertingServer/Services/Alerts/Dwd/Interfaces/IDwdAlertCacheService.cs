using CommonAlertingServer.Models.Alerts.Dwd;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommonAlertingServer.Services.Alerts.Dwd.Interfaces
{
    public interface IDwdAlertCacheService
    {
        IReadOnlyList<DwdAlert> GetDwdAlerts();
    }
}
