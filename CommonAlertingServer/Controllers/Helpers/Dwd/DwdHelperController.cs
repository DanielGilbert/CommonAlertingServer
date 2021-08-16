using CommonAlertingServer.Models.Helper.Dwd;
using CommonAlertingServer.Services.Helper.Dwd.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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
        public ActionResult<DwdPostalcodeHelperResponse> Get(string postalcode)
        {
            return Ok(_dwdHelperService.GetDwdPostalCodeHelperResponse(postalcode));
        }
    }
}
