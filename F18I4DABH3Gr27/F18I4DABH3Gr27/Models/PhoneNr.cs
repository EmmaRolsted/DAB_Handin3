using System.ComponentModel.DataAnnotations;

namespace F18I4DABH3Gr27.Models
{
    public class PhoneNr
    {
        //public PhoneNr() { }
        //public PhoneNr(string phonenumber, string phonetype, string phonecompany)
        //{
        //    PhoneNumber = phonenumber;
        //    PhoneType = phonetype;
        //    PhoneCompany = PhoneCompany;
        //}

        public int PhoneNrId { get; set; } //Default primary key

        [Required]
        public string PhoneNumber { get; set; }
        public string PhoneType { get; set; }
        public string PhoneCompany { get; set; }

        public int PersonId { get; set; } //Foreign key to Person class
        public Person Person { get; set; }
    }
}