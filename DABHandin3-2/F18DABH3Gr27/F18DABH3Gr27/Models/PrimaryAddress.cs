using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace F18DABH3Gr27.Models
{
    public class PrimaryAddress
    {
        public int Id { get; set; } //default primary key

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

        // Foreign key to person class
        public int PersonId { get; set; } 
        //Navigation property
        public Person Person { get; set; }
    }
}