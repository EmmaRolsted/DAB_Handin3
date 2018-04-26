namespace F18I4DABH3Gr27.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.AltAddresses", "PersonId");
            CreateIndex("dbo.Emails", "PersonId");
            CreateIndex("dbo.PhoneNrs", "PersonId");
            CreateIndex("dbo.PrimaryAddresses", "PersonId");
            AddForeignKey("dbo.AltAddresses", "PersonId", "dbo.People", "PersonId", cascadeDelete: true);
            AddForeignKey("dbo.Emails", "PersonId", "dbo.People", "PersonId", cascadeDelete: true);
            AddForeignKey("dbo.PhoneNrs", "PersonId", "dbo.People", "PersonId", cascadeDelete: true);
            AddForeignKey("dbo.PrimaryAddresses", "PersonId", "dbo.People", "PersonId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PrimaryAddresses", "PersonId", "dbo.People");
            DropForeignKey("dbo.PhoneNrs", "PersonId", "dbo.People");
            DropForeignKey("dbo.Emails", "PersonId", "dbo.People");
            DropForeignKey("dbo.AltAddresses", "PersonId", "dbo.People");
            DropIndex("dbo.PrimaryAddresses", new[] { "PersonId" });
            DropIndex("dbo.PhoneNrs", new[] { "PersonId" });
            DropIndex("dbo.Emails", new[] { "PersonId" });
            DropIndex("dbo.AltAddresses", new[] { "PersonId" });
        }
    }
}
