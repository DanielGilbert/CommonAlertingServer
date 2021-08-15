using CommonAlertingServer.Models.Helper.Dwd;
using CommonAlertingServer.Services.Helper.Dwd.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommonAlertingServer.Services.Helper.Dwd
{
    public class DwdHelperService : IDwdHelperService
    {
        public DwdPostalcodeHelperResponse GetDwdPostalCodeHelperResponse(string postalCode)
        {
            return new DwdPostalcodeHelperResponse() { Attribution = "© OpenStreetMap contributors | https://www.openstreetmap.org/copyright" };
        }
    }
}
