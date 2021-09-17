using CommonAlertingServer.Models.Alerts.Dwd;
using CommonAlertingServer.Services.Alerts.Dwd.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.Annotations;
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
        [SwaggerOperation(
            Summary = "Retrieves all warnings issued from the DWD",
            Description = "This route will return all active warnings. The warnings are currently being refreshed every 5 minutes.",
            OperationId = "GetWarnings",
            Tags = new[] { "/alerts/dwd" }
        )]
        [SwaggerResponse(200, "All available warnings issued by the DWD.", typeof(List<DwdAlert>))]
        public ActionResult<IList<DwdAlert>> Get([FromQuery] UrlQueryParameters urlQueryParameters)
        {
            _logger.LogDebug("Fetching alerts.");
            return Ok(_dwdAlertService.GetAlerts(urlQueryParameters.Limit, urlQueryParameters.Page));
        }


        [HttpGet("warncellids/{warncellid}")]
        [SwaggerOperation(
            Summary = "Retrieves a warning for a given warncellid",
            Description = "This route will return all active warnings for the given warncellid. The warnings are currently being refreshed every 5 minutes.",
            OperationId = "GetWarncellIdWarning",
            Tags = new[] { "/alerts/dwd" }
        )]
        [SwaggerResponse(200, "All available warnings for this warncellid", typeof(List<DwdAlert>))]
        public ActionResult<IList<DwdAlert>> Get(string warncellid, [FromQuery] UrlQueryParameters urlQueryParameters)
        {
            _logger.LogDebug($"Fetching alert for {warncellid}.");
            return Ok(_dwdAlertService.GetAlertsFor(warncellid, urlQueryParameters.Limit, urlQueryParameters.Page));
        }
    }
}
