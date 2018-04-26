using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace F18I4DABH3Gr27.Models
{
    public class PrimaryAddress
    {
        //public PrimaryAddress()
        //{
        //}

        //public PrimaryAddress(string primaryaddresstype, string streetname, string housenumber, string zipcode,
        //    string cityname)
        //{
        //    PrimaryAddressType = primaryaddresstype;
        //    StreetName = streetname;
        //    HouseNumber = housenumber;
        //    ZipCode = zipcode;
        //    CityName = cityname;
        //}
        public int PrimaryAddressId { get; set; } //default primary key

        [Required]
        public string PrimaryAddressType { get; set; }

        [Required]
        public string StreetName { get; set; }

        [Required]
        public string HouseNumber { get; set; }

        [Required]
        public string ZipCode { get; set; }

        [Required]
        public string CityName { get; set; }

        // Foreign key
        public int PersonId { get; set; } //Foreign key to Person class

        public Person Person { get; set; }
    }
}