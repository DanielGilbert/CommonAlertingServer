using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CommonAlertingServer.Models.Helper.Dwd
{
    [SwaggerSchema(Required = new[] { "PostalCode" })]
    public class DwdPostalcodeHelperResponse
    {
        /// <summary>
        /// The given postalcode.
        /// </summary>
        [JsonPropertyName("postalCode")]
        [SwaggerSchema("The provided postalcode", ReadOnly = false)]
        public string PostalCode { get; set; }
        /// <summary>
        /// The place this postal code refers tio
        /// </summary>
        [JsonPropertyName("place")]
        [SwaggerSchema("The given name of the place", ReadOnly = true)]
        public string Place { get; set; }
        /// <summary>
        /// The official municipality key for the postal code.
        /// </summary>
        [JsonPropertyName("officialMunicipalityKey")]
        [SwaggerSchema("The official municipality key", ReadOnly = true)]
        public string OfficialMunicipalityKey { get; set; }
        /// <summary>
        /// The calculated warncellId for this postal code.
        /// </summary>
        [JsonPropertyName("warncellId")]
        [SwaggerSchema("The final warncellid to use", ReadOnly = true)]
        public string WarncellId { get; set; }
        /// <summary>
        /// Propert attributiun for this dataset
        /// </summary>
        [JsonPropertyName("attribution")]
        [SwaggerSchema("The attribution", ReadOnly = true)]
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