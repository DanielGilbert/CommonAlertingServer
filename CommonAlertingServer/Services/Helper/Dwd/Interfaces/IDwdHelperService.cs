using CommonAlertingServer.Models.Helper.Dwd;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommonAlertingServer.Services.Helper.Dwd.Interfaces
{
    public interface IDwdHelperService
    {
        DwdPostalcodeHelperResponse GetDwdPostalCodeHelperResponse(string postalCode);
    }
}
