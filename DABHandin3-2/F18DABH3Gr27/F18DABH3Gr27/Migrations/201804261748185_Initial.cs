namespace F18DABH3Gr27.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AltAddresses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AltAddressType = c.String(),
                        StreetName = c.String(),
                        HouseNumber = c.String(),
                        ZipCode = c.String(),
                        CityName = c.String(),
                        PersonId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.People", t => t.PersonId, cascadeDelete: true)
                .Index(t => t.PersonId);
            
            CreateTable(
                "dbo.People",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Firstname = c.String(nullable: false),
                        MiddleName = c.String(),
                        LastName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Emails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EmailAddress = c.String(),
                        EmailType = c.String(),
                        PersonId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.People", t => t.PersonId, cascadeDelete: true)
                .Index(t => t.PersonId);
            
            CreateTable(
                "dbo.PhoneNRs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PhoneNumber = c.String(),
                        PhoneType = c.String(),
                        PhoneCompany = c.String(),
                        PersonId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.People", t => t.PersonId, cascadeDelete: true)
                .Index(t => t.PersonId);
            
            CreateTable(
                "dbo.PrimaryAddresses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PrimaryAddressType = c.String(nullable: false),
                        StreetName = c.String(nullable: false),
                        HouseNumber = c.String(nullable: false),
                        ZipCode = c.String(nullable: false),
                        CityName = c.String(nullable: false),
                        PersonId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.People", t => t.PersonId, cascadeDelete: true)
                .Index(t => t.PersonId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PrimaryAddresses", "PersonId", "dbo.People");
            DropForeignKey("dbo.PhoneNRs", "PersonId", "dbo.People");
            DropForeignKey("dbo.Emails", "PersonId", "dbo.People");
            DropForeignKey("dbo.AltAddresses", "PersonId", "dbo.People");
            DropIndex("dbo.PrimaryAddresses", new[] { "PersonId" });
            DropIndex("dbo.PhoneNRs", new[] { "PersonId" });
            DropIndex("dbo.Emails", new[] { "PersonId" });
            DropIndex("dbo.AltAddresses", new[] { "PersonId" });
            DropTable("dbo.PrimaryAddresses");
            DropTable("dbo.PhoneNRs");
            DropTable("dbo.Emails");
            DropTable("dbo.People");
            DropTable("dbo.AltAddresses");
        }
    }
}
