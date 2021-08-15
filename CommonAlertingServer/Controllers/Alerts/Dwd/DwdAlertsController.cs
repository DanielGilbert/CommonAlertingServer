using CommonAlertingServer.Models.Alerts.Dwd;
using CommonAlertingServer.Services.Alerts.Dwd.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommonAlertingServer.Controllers.Dwd
{
    [ApiController]
    [Route("alerts/dwd")]
    public class DwdAlertsController : ControllerBase
    {
        private readonly ILogger<DwdAlertsController> _logger;
        private readonly IDwdAlertService _dwdAlertService;

        public DwdAlertsController(ILogger<DwdAlertsController> logger, IDwdAlertService dwdAlertService)
        {
            _logger = logger;
            _dwdAlertService = dwdAlertService;
        }

        [HttpGet]
        public IEnumerable<DwdAlert> Get()
        {
            return _dwdAlertService.GetAlerts();
        }
    }
}
