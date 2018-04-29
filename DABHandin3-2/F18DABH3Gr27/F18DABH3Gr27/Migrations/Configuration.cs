namespace F18DABH3Gr27.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using F18DABH3Gr27.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<F18DABH3Gr27.Models.F18DABH3Gr27Context>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(F18DABH3Gr27.Models.F18DABH3Gr27Context context)
        {
            context.People.AddOrUpdate(x=> x.Id,
                new Person() {Id = 1, Firstname = "Emma", LastName = "Rolsted"},
                new Person() {Id = 2, Firstname = "Susanne", LastName = "Olsen"},
                new Person() {Id = 3, Firstname = "Armina", MiddleName = "Isabella", LastName = "Sanjarizadeh"}
                );

            context.PrimaryAddresses.AddOrUpdate(x=> x.Id,
                new PrimaryAddress()
                {
                    Id = 1,
                    StreetName = "Klokkerfaldet",
                    HouseNumber = "54",
                    ZipCode = "8210",
                    CityName = "Aarhus V",
                    PrimaryAddressType = "Privat",
                    PersonId = 1
                },
                new PrimaryAddress()
                {
                    Id = 2,
                    StreetName = "Sletterhagevej",
                    HouseNumber = "1, 1. tv",
                    CityName = "Risskov",
                    ZipCode = "8240",
                    PrimaryAddressType = "Privat",
                    PersonId = 2
                },
                new PrimaryAddress()
                {
                    Id = 3,
                    StreetName = "Haslevej",
                    HouseNumber = "6",
                    CityName = "Aabyhoej",
                    ZipCode = "8230",
                    PrimaryAddressType = "Privat",
                    PersonId = 3,
                });

            context.PhoneNRs.AddOrUpdate(x=> x.Id,
                new PhoneNR() {Id = 1, PersonId = 1, PhoneNumber = "12341234"},
                new PhoneNR() {Id = 1, PersonId = 2, PhoneNumber = "12345678"},
                new PhoneNR() {Id = 3, PersonId = 3, PhoneNumber = "87654321"});
            
        }
    }
}
