namespace CYBInfracstructure.DataStructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class useracc : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserAccount", "Role_RoleId", c => c.Int());
            CreateIndex("dbo.UserAccount", "Role_RoleId");
            AddForeignKey("dbo.UserAccount", "Role_RoleId", "dbo.Role", "RoleId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserAccount", "Role_RoleId", "dbo.Role");
            DropIndex("dbo.UserAccount", new[] { "Role_RoleId" });
            DropColumn("dbo.UserAccount", "Role_RoleId");
        }
    }
}
