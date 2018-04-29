using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace F18DABH3Gr27.Models
{
    public class PhoneNR
    {
        public int Id { get; set; }
        public string PhoneNumber { get; set; }
        public string PhoneType { get; set; }
        public string PhoneCompany { get; set; }

        //Foreign Key
        public int PersonId { get; set; }
        //Navigation Property
        public Person Person { get; set; }
    }
}