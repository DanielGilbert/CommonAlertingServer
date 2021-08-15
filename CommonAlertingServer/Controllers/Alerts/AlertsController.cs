using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommonAlertingServer.Controllers.Alerts
{
    [ApiController]
    [Route("[controller]")]
    public class AlertsController : ControllerBase
    {
        private readonly ILogger<AlertsController> _logger;

        public AlertsController(ILogger<AlertsController> logger)
        {
            _logger = logger;
        }
    }
}
