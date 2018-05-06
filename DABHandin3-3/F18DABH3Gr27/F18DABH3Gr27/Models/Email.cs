using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

//// Followed tutorial to create Repository:  https://docs.microsoft.com/en-us/azure/cosmos-db/sql-api-dotnet-application

namespace F18DABH3Gr27.Models
{
    public class Email
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; } //default primary key

        [JsonProperty(PropertyName = "emailAddress")]
        public string EmailAddress { get; set; }

        [JsonProperty(PropertyName = "emailType")]
        public string EmailType { get; set; }
    }
}