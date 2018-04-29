using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace F18DABH3Gr27.Models
{
    public class AltAddress
    {
        public int Id { get; set; } //Default primary key

        //[Key]
        public string AltAddressType { get; set; }
        public string StreetName { get; set; }
        public string HouseNumber { get; set; }
        public string ZipCode { get; set; }
        public string CityName { get; set; }

        //Foreign Key
        public int PersonId { get; set; }
        //Navigation Property
        public Person Person { get; set; }
    }
}