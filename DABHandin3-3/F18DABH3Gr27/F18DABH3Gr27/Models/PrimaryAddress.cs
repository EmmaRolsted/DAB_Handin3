using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace F18DABH3Gr27.Models
{
    public class PrimaryAddress
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }

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