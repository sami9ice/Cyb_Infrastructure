namespace CYBInfracstructure.DataStructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class onetomany2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Role", "UserAccount_UserID", "dbo.UserAccount");
            AddColumn("dbo.Role", "UserAccount_UserID1", c => c.Int());
            AddColumn("dbo.UserAccount", "Role_RoleId", c => c.Int());
            AddColumn("dbo.UserAccount", "Role_RoleId1", c => c.Int());
            CreateIndex("dbo.Role", "UserAccount_UserID1");
            CreateIndex("dbo.UserAccount", "Role_RoleId");
            CreateIndex("dbo.UserAccount", "Role_RoleId1");
            AddForeignKey("dbo.UserAccount", "Role_RoleId", "dbo.Role", "RoleId");
            AddForeignKey("dbo.UserAccount", "Role_RoleId1", "dbo.Role", "RoleId");
            AddForeignKey("dbo.Role", "UserAccount_UserID1", "dbo.UserAccount", "UserID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Role", "UserAccount_UserID1", "dbo.UserAccount");
            DropForeignKey("dbo.UserAccount", "Role_RoleId1", "dbo.Role");
            DropForeignKey("dbo.UserAccount", "Role_RoleId", "dbo.Role");
            DropIndex("dbo.UserAccount", new[] { "Role_RoleId1" });
            DropIndex("dbo.UserAccount", new[] { "Role_RoleId" });
            DropIndex("dbo.Role", new[] { "UserAccount_UserID1" });
            DropColumn("dbo.UserAccount", "Role_RoleId1");
            DropColumn("dbo.UserAccount", "Role_RoleId");
            DropColumn("dbo.Role", "UserAccount_UserID1");
            AddForeignKey("dbo.Role", "UserAccount_UserID", "dbo.UserAccount", "UserID");
        }
    }
}
