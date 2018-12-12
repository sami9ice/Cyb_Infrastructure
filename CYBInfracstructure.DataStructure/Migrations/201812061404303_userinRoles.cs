namespace CYBInfracstructure.DataStructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class userinRoles : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Role", "GetUsersInRole_UserId", c => c.Int());
            CreateIndex("dbo.Role", "GetUsersInRole_UserId");
            AddForeignKey("dbo.Role", "GetUsersInRole_UserId", "dbo.UsersInRoles", "UserId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Role", "GetUsersInRole_UserId", "dbo.UsersInRoles");
            DropIndex("dbo.Role", new[] { "GetUsersInRole_UserId" });
            DropColumn("dbo.Role", "GetUsersInRole_UserId");
        }
    }
}
