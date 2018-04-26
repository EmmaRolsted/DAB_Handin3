namespace F18I4DABH3Gr27.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using F18I4DABH3Gr27.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<F18I4DABH3Gr27.Models.F18I4DABH3Gr27Context>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(F18I4DABH3Gr27.Models.F18I4DABH3Gr27Context context)
        {
            context.People.AddOrUpdate(x => x.PersonId,
                new Models.Person() { PersonId = 1, Name = "Emma", LastName = "Rolsted"},
                new Models.Person() {PersonId = 2, Name = "Suanne", LastName = "Olsen"},
                new Models.Person() {PersonId = 3, Name = "Armina", MiddleName = "Isabella", LastName = "Sanjarizadeh"}
                );

            context.PrimaryAddresses.AddOrUpdate(x => x.PrimaryAddressId,
                new Models.PrimaryAddress()
                {
                    PrimaryAddressId = 1,
                    StreetName = "Klokkerfaldet",
                    HouseNumber = "54",
                    CityName = "Aarhus",
                    ZipCode = "8210",
                    PrimaryAddressType = "Private",
                    PersonId = 1
                },
                new Models.PrimaryAddress()
                {
                    PrimaryAddressId = 2,
                    StreetName = "Sletterhagevej",
                    HouseNumber = "1, 1. tv",
                    CityName = "Risskov",
                    ZipCode = "8240",
                    PrimaryAddressType = "Privat",
                    PersonId = 2
                },
                new Models.PrimaryAddress()
                {
                    PrimaryAddressId = 3,
                    StreetName = "Haslevej",
                    HouseNumber = "6",
                    CityName = "Aabyhoej",
                    ZipCode = "8230",
                    PrimaryAddressType = "Privat",
                    PersonId = 3,
                }
                
            );
            
            context.PhoneNrs.AddOrUpdate(x=> x.PhoneNrId,
                new Models.PhoneNr()
                {
                    PersonId = 1,
                    PhoneNrId = 1,
                    PhoneNumber = "12345678",
                },
                new Models.PhoneNr()
                {
                    PersonId = 2,
                    PhoneNrId = 2,
                    PhoneNumber = "24681012"
                },
                new Models.PhoneNr()
                {
                    PersonId = 3,
                    PhoneNrId = 3,
                    PhoneNumber = "36912151"
                });
        }
    }
}
