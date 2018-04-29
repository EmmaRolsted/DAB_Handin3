using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace F18DABH3Gr27.Models
{
    public class Email
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; } //default primary key

        public string EmailAddress { get; set; }
        public string EmailType { get; set; }
    }
}