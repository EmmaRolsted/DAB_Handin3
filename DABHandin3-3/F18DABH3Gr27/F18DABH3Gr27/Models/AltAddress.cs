using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace F18DABH3Gr27.Models
{
    public class AltAddress
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "altAddressType")]
        public string AltAddressType { get; set; }

        [JsonProperty(PropertyName = "streetName")]
        public string StreetName { get; set; }

        [JsonProperty(PropertyName = "houseNumber")]
        public string HouseNumber { get; set; }

        [JsonProperty(PropertyName = "zipCode")]
        public string ZipCode { get; set; }

        [JsonProperty(PropertyName = "cityName")]
        public string CityName { get; set; }
    }
}