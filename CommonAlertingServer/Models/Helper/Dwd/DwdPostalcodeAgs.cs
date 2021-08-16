using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CsvHelper.Configuration.Attributes;

namespace CommonAlertingServer.Models.Helper.Dwd
{
    public class DwdPostalcodeAgs
    {
        [Name("ags")]
        public string Ags { get; set; }
        [Name("ort")]
        public string Place { get; set; }
        [Name("plz")]
        public string Postalcode { get; set; }
        [Name("landkreis")]
        public string Landkreis { get; set; }
        [Name("bundesland")]
        public string State { get; set; }
    }
}
