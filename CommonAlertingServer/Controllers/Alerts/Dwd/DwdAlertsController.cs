using CommonAlertingServer.Models.Alerts.Dwd;
using CommonAlertingServer.Services.Alerts.Dwd.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace CommonAlertingServer.Controllers.Dwd
{
    public record UrlQueryParameters(int Limit = 50, int Page = 1);

    /// <summary>
    /// Provides weather alerts from the DWD, mapped to json.
    /// </summary>
    [ApiController]
    [Route("alerts/dwd")]
    [Produces("application/json")]
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
        public ActionResult<IList<DwdAlert>> Get([FromQuery] UrlQueryParameters urlQueryParameters)
        {
            _logger.LogDebug("Fetching alerts.");
            return Ok(_dwdAlertService.GetAlerts(urlQueryParameters.Limit, urlQueryParameters.Page));
        }

        [HttpGet("warncellids/{warncellid}")]
        public ActionResult<IList<DwdAlert>> Get(string warncellid, [FromQuery] UrlQueryParameters urlQueryParameters)
        {
            _logger.LogDebug($"Fetching alert for {warncellid}.");
            return Ok(_dwdAlertService.GetAlertsFor(warncellid, urlQueryParameters.Limit, urlQueryParameters.Page));
        }
    }
}
