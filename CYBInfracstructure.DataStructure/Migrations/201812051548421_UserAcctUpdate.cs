namespace CYBInfracstructure.DataStructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserAcctUpdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserAccount", "StaffID", c => c.String(nullable: false));
            AddColumn("dbo.UserAccount", "StaffName", c => c.String(nullable: false));
            AddColumn("dbo.UserAccount", "Email", c => c.String(nullable: false));
            DropColumn("dbo.UserAccount", "Roles");
            DropColumn("dbo.UserAccount", "LastName");
            DropColumn("dbo.UserAccount", "Username");
        }
        
        public override void Down()
        {
            AddColumn("dbo.UserAccount", "Username", c => c.String(nullable: false));
            AddColumn("dbo.UserAccount", "LastName", c => c.String(nullable: false));
            AddColumn("dbo.UserAccount", "Roles", c => c.String(nullable: false));
            DropColumn("dbo.UserAccount", "Email");
            DropColumn("dbo.UserAccount", "StaffName");
            DropColumn("dbo.UserAccount", "StaffID");
        }
    }
}
