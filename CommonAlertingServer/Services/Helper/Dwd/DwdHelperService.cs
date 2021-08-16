using CommonAlertingServer.Models.Helper.Dwd;
using CommonAlertingServer.Services.Helper.Dwd.Interfaces;
using CsvHelper;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CommonAlertingServer.Services.Helper.Dwd
{
    public class DwdHelperService : IDwdHelperService
    {
        private readonly ILogger<DwdHelperService> _logger;
        private readonly IEnumerable<DwdPostalcodeAgs> _dwdPostalcodeAgsList;

        public DwdHelperService(ILogger<DwdHelperService> logger)
        {
            _logger = logger;

            _dwdPostalcodeAgsList = new List<DwdPostalcodeAgs>();

            using (var reader = new StreamReader("DataSet\\Dwd\\zuordnung_plz_ort_landkreis.csv"))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                _dwdPostalcodeAgsList = csv.GetRecords<DwdPostalcodeAgs>();
            }
            
        }

        public DwdPostalcodeHelperResponse GetDwdPostalCodeHelperResponse(string postalCode)
        {
            return new DwdPostalcodeHelperResponse() { Attribution = "© OpenStreetMap contributors | https://www.openstreetmap.org/copyright" };
        }
    }
}
