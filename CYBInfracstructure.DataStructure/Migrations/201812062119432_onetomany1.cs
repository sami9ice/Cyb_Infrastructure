namespace CYBInfracstructure.DataStructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class onetomany1 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.UsersInRoles", "UserAccountId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.UsersInRoles", "UserAccountId", c => c.Int(nullable: false));
        }
    }
}
