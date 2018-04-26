using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace F18I4DABH3Gr27.Models
{
    public class Person
    {
        
        public int PersonId { get; set; } //Default primary key
        [Required]
        public string Name { get; set; }
        public string MiddleName { get; set; }
        [Required]
        public string LastName { get; set; }

        //public string EmailAddress { get; set; } // Primary key i Email klassen, men den bliver foreing key her.
        //public int EmailId { get; set; } //Foreign key to email table
        //public Email Email { get; set; } // Navigation property

        //public string PhoneNumber { get; set; } 
        //public int PhoneNrId { get; set; } //Foreign key to phonenr table
        //public PhoneNr PhoneNr { get; set; } // Navigation property - SKAL MÅSKE VÆRE VIRTUEL!!!


        //public string PrimaryAddressType { get; set; }

        //public int PrimaryAddressId { get; set; }


        //public PrimaryAddress PrimaryAddress { get; set; }

        //public string AltAddressType { get; set; }
        //public int AltAddressId { get; set; } //Foreign key to AltAddress
        //public AltAddress AltAddress { get; set; }//Navigation property


    }
}