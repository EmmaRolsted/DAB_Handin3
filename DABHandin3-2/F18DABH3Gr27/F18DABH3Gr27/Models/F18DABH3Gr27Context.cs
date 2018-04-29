using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace F18DABH3Gr27.Models
{
    public class F18DABH3Gr27Context : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public F18DABH3Gr27Context() : base("name=F18DABH3Gr27Context")
        {
        }

        public System.Data.Entity.DbSet<F18DABH3Gr27.Models.Person> People { get; set; }

        public System.Data.Entity.DbSet<F18DABH3Gr27.Models.AltAddress> AltAddresses { get; set; }

        public System.Data.Entity.DbSet<F18DABH3Gr27.Models.Email> Emails { get; set; }

        public System.Data.Entity.DbSet<F18DABH3Gr27.Models.PhoneNR> PhoneNRs { get; set; }

        public System.Data.Entity.DbSet<F18DABH3Gr27.Models.PrimaryAddress> PrimaryAddresses { get; set; }
    }
}
