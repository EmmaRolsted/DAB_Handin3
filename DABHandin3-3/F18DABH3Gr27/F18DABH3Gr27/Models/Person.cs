using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace F18DABH3Gr27.Models
{
    public class Person
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }
        public string Firstname { get; set; }
        public string MiddleName { get; set; }
        //Persons lastname
        public string LastName { get; set; }

        public AltAddress AltAddress { get; set; }
        public PrimaryAddress PrimaryAddress { get; set; }
        public PhoneNR PhoneNR { get; set; }
        public Email Email { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}