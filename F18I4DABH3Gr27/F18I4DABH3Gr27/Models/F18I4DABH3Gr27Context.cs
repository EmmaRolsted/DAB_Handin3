using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace F18I4DABH3Gr27.Models
{
    public class F18I4DABH3Gr27Context : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public F18I4DABH3Gr27Context() : base("name=F18I4DABH3Gr27Context") //"name=HandIn3-2" name=HandIn3-2""name=F18I4DABH3Gr27Context"
        {
            this.Database.Log = s => System.Diagnostics.Debug.WriteLine(s);
        }

        public System.Data.Entity.DbSet<F18I4DABH3Gr27.Models.Person> People { get; set; }

        public System.Data.Entity.DbSet<F18I4DABH3Gr27.Models.AltAddress> AltAddresses { get; set; }

        public System.Data.Entity.DbSet<F18I4DABH3Gr27.Models.Email> Emails { get; set; }

        public System.Data.Entity.DbSet<F18I4DABH3Gr27.Models.PhoneNr> PhoneNrs { get; set; }

        public System.Data.Entity.DbSet<F18I4DABH3Gr27.Models.PrimaryAddress> PrimaryAddresses { get; set; }
    }
}
