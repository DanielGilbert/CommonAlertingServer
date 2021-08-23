using CommonAlertingServer.Models.Alerts.Dwd;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommonAlertingServer.Services.Alerts.Dwd.Interfaces
{
    public interface IDwdAlertCacheService : IHostedService
    {
        IReadOnlyList<DwdAlert> GetDwdAlerts();
    }
}
