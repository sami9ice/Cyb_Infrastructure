namespace CYBInfracstructure.DataStructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class roles : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.UserAccount", "Role_RoleId", "dbo.Role");
            DropForeignKey("dbo.Role", "UserAccount_UserID", "dbo.UserAccount");
            DropForeignKey("dbo.Role", "UserAccount_UserID1", "dbo.UserAccount");
            DropForeignKey("dbo.UserAccount", "Role_RoleId1", "dbo.Role");
            DropIndex("dbo.Role", new[] { "UserAccount_UserID" });
            DropIndex("dbo.Role", new[] { "UserAccount_UserID1" });
            DropIndex("dbo.UserAccount", new[] { "Role_RoleId" });
            DropIndex("dbo.UserAccount", new[] { "Role_RoleId1" });
            DropPrimaryKey("dbo.UsersInRoles");
            DropColumn("dbo.Role", "UserAccountId");
            DropColumn("dbo.Role", "UserAccount_UserID");
            DropColumn("dbo.Role", "UserAccount_UserID1");
            DropColumn("dbo.UserAccount", "Role_RoleId");
            DropColumn("dbo.UserAccount", "Role_RoleId1");
            DropColumn("dbo.UsersInRoles", "UserId");
            AddColumn("dbo.Role", "Description", c => c.String());
            AddColumn("dbo.UsersInRoles", "Id", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.UsersInRoles", "UserAccountId", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.UsersInRoles", "Id");
           
        }
        
        public override void Down()
        {
            AddColumn("dbo.UsersInRoles", "UserId", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.UserAccount", "Role_RoleId1", c => c.Int());
            AddColumn("dbo.UserAccount", "Role_RoleId", c => c.Int());
            AddColumn("dbo.Role", "UserAccount_UserID1", c => c.Int());
            AddColumn("dbo.Role", "UserAccount_UserID", c => c.Int());
            AddColumn("dbo.Role", "UserAccountId", c => c.Int(nullable: false));
            DropPrimaryKey("dbo.UsersInRoles");
            DropColumn("dbo.UsersInRoles", "UserAccountId");
            DropColumn("dbo.UsersInRoles", "Id");
            DropColumn("dbo.Role", "Description");
            AddPrimaryKey("dbo.UsersInRoles", "UserId");
            CreateIndex("dbo.UserAccount", "Role_RoleId1");
            CreateIndex("dbo.UserAccount", "Role_RoleId");
            CreateIndex("dbo.Role", "UserAccount_UserID1");
            CreateIndex("dbo.Role", "UserAccount_UserID");
            AddForeignKey("dbo.UserAccount", "Role_RoleId1", "dbo.Role", "RoleId");
            AddForeignKey("dbo.Role", "UserAccount_UserID1", "dbo.UserAccount", "UserID");
            AddForeignKey("dbo.Role", "UserAccount_UserID", "dbo.UserAccount", "UserID");
            AddForeignKey("dbo.UserAccount", "Role_RoleId", "dbo.Role", "RoleId");
        }
    }
}
