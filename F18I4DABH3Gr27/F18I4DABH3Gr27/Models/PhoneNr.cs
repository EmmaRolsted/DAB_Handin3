using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace F18I4DABH3Gr27.Models
{
    public class PhoneNr
    {
        public PhoneNr() { }
        public PhoneNr(string phonenumber, string phonetype, string phonecompany)
        {
            PhoneNumber = phonenumber;
            PhoneType = phonetype;
            PhoneCompany = PhoneCompany;
        }

        public int PhoneId { get; set; }

        [Key]
        public string PhoneNumber { get; set; }
        public string PhoneType { get; set; }
        public string PhoneCompany { get; set; }
    }
}