namespace CYBInfracstructure.DataStructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class date : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CredentialSetup", "Date", c => c.DateTime(nullable: false));
            AddColumn("dbo.Host", "Date", c => c.DateTime(nullable: false));
            AddColumn("dbo.Inventory", "Date", c => c.DateTime(nullable: false));
            AddColumn("dbo.Inventory", "DescriptionOfServicesOffered", c => c.String());
            AddColumn("dbo.Location", "Date", c => c.DateTime(nullable: false));
            AddColumn("dbo.Department", "Date", c => c.DateTime(nullable: false));
            AddColumn("dbo.Unit", "Date", c => c.DateTime(nullable: false));
            AddColumn("dbo.Services", "Date", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Services", "Date");
            DropColumn("dbo.Unit", "Date");
            DropColumn("dbo.Department", "Date");
            DropColumn("dbo.Location", "Date");
            DropColumn("dbo.Inventory", "DescriptionOfServicesOffered");
            DropColumn("dbo.Inventory", "Date");
            DropColumn("dbo.Host", "Date");
            DropColumn("dbo.CredentialSetup", "Date");
        }
    }
}
