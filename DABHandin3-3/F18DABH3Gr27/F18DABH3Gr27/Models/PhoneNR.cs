using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace F18DABH3Gr27.Models
{
    public class PhoneNR
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }
        public string PhoneNumber { get; set; }
        public string PhoneType { get; set; }
        public string PhoneCompany { get; set; }

    }
}