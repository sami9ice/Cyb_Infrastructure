namespace CYBInfracstructure.DataStructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class onetomany11 : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.UsersInRoles", "RoleId");
            AddForeignKey("dbo.UsersInRoles", "RoleId", "dbo.Role", "RoleId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UsersInRoles", "RoleId", "dbo.Role");
            DropIndex("dbo.UsersInRoles", new[] { "RoleId" });
        }
    }
}
