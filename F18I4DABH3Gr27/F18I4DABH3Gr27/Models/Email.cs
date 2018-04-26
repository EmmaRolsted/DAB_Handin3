using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace F18I4DABH3Gr27.Models//
{
    public class Email
    {
        public Email(){}
        public Email(string emailAddress, string emailType)
        {
            EmailAddress = emailAddress;
            EmailType = emailType;
        }

        //public int EmailId { get; set; }

        [Key] //specificer den efterfølgende funktion som primarykey
        public string EmailAddress { get; set; }
        public string EmailType { get; set; }
    }
}