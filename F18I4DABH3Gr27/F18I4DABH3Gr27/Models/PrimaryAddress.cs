using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace F18I4DABH3Gr27.Models
{
    public class PrimaryAddress
    {
        public PrimaryAddress()
        {
        }

        public PrimaryAddress(string primaryaddresstype, string streetname, string housenumber, string zipcode,
            string cityname)
        {
            PrimaryAddressType = primaryaddresstype;
            StreetName = streetname;
            HouseNumber = housenumber;
            ZipCode = zipcode;
            CityName = cityname;
        }
        public int PrimaryId { get; set; }

        [Key]
        public string PrimaryAddressType { get; set; }
        public string StreetName { get; set; }
        public string HouseNumber { get; set; }
        public string ZipCode { get; set; }
        public string CityName { get; set; }
    }
}