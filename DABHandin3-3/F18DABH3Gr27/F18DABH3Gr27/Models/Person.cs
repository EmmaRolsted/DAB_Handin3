using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

//// Followed tutorial to create Repository:  https://docs.microsoft.com/en-us/azure/cosmos-db/sql-api-dotnet-application

namespace F18DABH3Gr27.Models
{
    public class Person
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "firstName")]
        public string Firstname { get; set; }

        [JsonProperty(PropertyName = "middleName")]
        public string MiddleName { get; set; }

        [JsonProperty(PropertyName = "lastName")]
        public string LastName { get; set; }

        public AltAddress AltAddress { get; set; }
        public PrimaryAddress PrimaryAddress { get; set; }
        public PhoneNR PhoneNR { get; set; }
        public Email Email { get; set; }

        //public override string ToString()
        //{
        //    return JsonConvert.SerializeObject(this);
        //}
    }
}