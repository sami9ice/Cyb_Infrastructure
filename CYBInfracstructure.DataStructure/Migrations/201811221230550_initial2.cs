namespace CYBInfracstructure.DataStructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserAccount", "Roles", c => c.String(nullable: false));
            DropColumn("dbo.UserAccount", "FirstName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.UserAccount", "FirstName", c => c.String(nullable: false));
            DropColumn("dbo.UserAccount", "Roles");
        }
    }
}
