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
        public string AltAddressType { get; set; }
        public string StreetName { get; set; }
        public string HouseNumber { get; set; }
        public string ZipCode { get; set; }
        public string CityName { get; set; }
    }
}