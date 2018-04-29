using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace F18DABH3Gr27.Models
{
    public class Email
    {
        public int Id { get; set; } //default primary key

        public string EmailAddress { get; set; }
        public string EmailType { get; set; }

        //Foreign key to Person class
        public int PersonId { get; set; } 

        //Navigation property
        public Person Person { get; set; }
    }
}