using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace F18I4DABH3Gr27.Models
{
    public class AltAddress
    {
        public AltAddress()
        { }

        public AltAddress(string altadresstype, string streetname, string housenumber, string zipcode,
            string cityname)
        {
            AltAddressType = altadresstype;
            StreetName = streetname;
            HouseNumber = housenumber;
            ZipCode = zipcode;
            CityName = cityname;
        }

        public int AltAddressId { get; set; }

        [Key]
        public string AltAddressType { get; set; }
        public string StreetName { get; set; }
        public string HouseNumber { get; set; }
        public string ZipCode { get; set; }
        public string CityName { get; set; }
    }
}