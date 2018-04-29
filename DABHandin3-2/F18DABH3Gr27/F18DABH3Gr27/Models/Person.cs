using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace F18DABH3Gr27.Models
{
    public class Person
    {
        //Maybe change Id to an string value.. Int keeps incrementing Id
        public int Id { get; set; } //Default primary key

        [Required] 
        public string Firstname { get; set; }
        public string MiddleName { get; set; }

        [Required]
        public string LastName { get; set; }
    }
}