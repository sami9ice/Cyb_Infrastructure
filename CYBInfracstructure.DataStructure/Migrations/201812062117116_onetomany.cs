namespace CYBInfracstructure.DataStructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class onetomany : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Role", "GetUsersInRole_UserId", "dbo.UsersInRoles");
            DropForeignKey("dbo.UserAccount", "Role_RoleId", "dbo.Role");
            DropIndex("dbo.Role", new[] { "GetUsersInRole_UserId" });
            DropIndex("dbo.UserAccount", new[] { "Role_RoleId" });
            AddColumn("dbo.Role", "UserAccountId", c => c.Int(nullable: false));
            AddColumn("dbo.Role", "UserAccount_UserID", c => c.Int());
            AddColumn("dbo.UsersInRoles", "UserAccountId", c => c.Int(nullable: false));
            AddColumn("dbo.UsersInRoles", "UserAccount_UserID", c => c.Int());
            CreateIndex("dbo.Role", "UserAccount_UserID");
            CreateIndex("dbo.UsersInRoles", "UserAccount_UserID");
            AddForeignKey("dbo.Role", "UserAccount_UserID", "dbo.UserAccount", "UserID");
            AddForeignKey("dbo.UsersInRoles", "UserAccount_UserID", "dbo.UserAccount", "UserID");
            DropColumn("dbo.Role", "GetUsersInRole_UserId");
            DropColumn("dbo.UserAccount", "Role_RoleId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.UserAccount", "Role_RoleId", c => c.Int());
            AddColumn("dbo.Role", "GetUsersInRole_UserId", c => c.Int());
            DropForeignKey("dbo.UsersInRoles", "UserAccount_UserID", "dbo.UserAccount");
            DropForeignKey("dbo.Role", "UserAccount_UserID", "dbo.UserAccount");
            DropIndex("dbo.UsersInRoles", new[] { "UserAccount_UserID" });
            DropIndex("dbo.Role", new[] { "UserAccount_UserID" });
            DropColumn("dbo.UsersInRoles", "UserAccount_UserID");
            DropColumn("dbo.UsersInRoles", "UserAccountId");
            DropColumn("dbo.Role", "UserAccount_UserID");
            DropColumn("dbo.Role", "UserAccountId");
            CreateIndex("dbo.UserAccount", "Role_RoleId");
            CreateIndex("dbo.Role", "GetUsersInRole_UserId");
            AddForeignKey("dbo.UserAccount", "Role_RoleId", "dbo.Role", "RoleId");
            AddForeignKey("dbo.Role", "GetUsersInRole_UserId", "dbo.UsersInRoles", "UserId");
        }
    }
}
