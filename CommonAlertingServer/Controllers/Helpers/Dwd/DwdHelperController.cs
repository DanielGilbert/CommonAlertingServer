using CommonAlertingServer.Models.Helper.Dwd;
using CommonAlertingServer.Services.Helper.Dwd.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommonAlertingServer.Controllers.Helpers.Dwd
{
    [ApiController]
    [Route("helper/dwd")]
    [Produces("application/json")]
    public class DwdHelperController : ControllerBase
    {
        private readonly ILogger<DwdHelperController> _logger;
        private readonly IDwdHelperService _dwdHelperService;

        public DwdHelperController(ILogger<DwdHelperController> logger, IDwdHelperService dwdHelperService)
        {
            _logger = logger;
            _dwdHelperService = dwdHelperService;
        }

        [HttpGet("postalcode/{postalcode}")]
        [SwaggerOperation(
            Summary = "Retrieves the warncellid for a given postalcode",
            Description = "This route will map a given postalcode (from Germany) to a warncellid.",
            OperationId = "GetWarncellIdFromPostalcode",
            Tags = new[] { "/helper/dwd" }
        )]
        [SwaggerResponse(200, "The WarncellId for a given postalcode", typeof(DwdPostalcodeHelperResponse))]
        public ActionResult<DwdPostalcodeHelperResponse> Get(string postalcode)
        {
            _logger.LogInformation($"Looking up {postalcode}");
            return Ok(_dwdHelperService.GetDwdPostalCodeHelperResponse(postalcode));
        }
    }
}
