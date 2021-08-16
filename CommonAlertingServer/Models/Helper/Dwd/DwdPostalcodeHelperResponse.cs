using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CommonAlertingServer.Models.Helper.Dwd
{
    public class DwdPostalcodeHelperResponse
    {
        /// <summary>
        /// The given postalcode.
        /// </summary>
        [JsonPropertyName("postalCode")]
        public string PostalCode { get; set; }
        /// <summary>
        /// The place this postal code refers tio
        /// </summary>
        [JsonPropertyName("place")]
        public string Place { get; set; }
        /// <summary>
        /// The official municipality key for the postal code.
        /// </summary>
        [JsonPropertyName("officialMunicipalityKey")]
        public string OfficialMunicipalityKey { get; set; }
        /// <summary>
        /// The calculated warncellId for this postal code.
        /// </summary>
        [JsonPropertyName("warncellId")]
        public string WarncellId { get; set; }
        /// <summary>
        /// Propert attributiun for this dataset
        /// </summary>
        [JsonPropertyName("attribution")]
        public string Attribution { get; set; }

        public DwdPostalcodeHelperResponse(DwdPostalcodeAgs result)
        {
            if (result != null)
            {
                WarncellId = "8" + result.Ags;
                OfficialMunicipalityKey = result.Ags;
                Place = result.Place;
                PostalCode = result.Postalcode;
            }

            Attribution = "© OpenStreetMap contributors | https://www.openstreetmap.org/copyright";
        }

    }
}