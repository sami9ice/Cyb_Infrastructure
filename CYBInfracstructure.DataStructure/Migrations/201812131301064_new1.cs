namespace CYBInfracstructure.DataStructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class new1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.UsersInRoles", "UserAccount_UserID", "dbo.UserAccount");
            DropIndex("dbo.UsersInRoles", new[] { "UserAccount_UserID" });
            RenameColumn(table: "dbo.UsersInRoles", name: "UserAccount_UserID", newName: "UserID");
            AlterColumn("dbo.UsersInRoles", "UserID", c => c.Int(nullable: false));
            CreateIndex("dbo.UsersInRoles", "UserID");
            AddForeignKey("dbo.UsersInRoles", "UserID", "dbo.UserAccount", "UserID", cascadeDelete: false);
            DropColumn("dbo.UsersInRoles", "UserAccountId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.UsersInRoles", "UserAccountId", c => c.Int(nullable: false));
            DropForeignKey("dbo.UsersInRoles", "UserID", "dbo.UserAccount");
            DropIndex("dbo.UsersInRoles", new[] { "UserID" });
            AlterColumn("dbo.UsersInRoles", "UserID", c => c.Int());
            RenameColumn(table: "dbo.UsersInRoles", name: "UserID", newName: "UserAccount_UserID");
            CreateIndex("dbo.UsersInRoles", "UserAccount_UserID");
            AddForeignKey("dbo.UsersInRoles", "UserAccount_UserID", "dbo.UserAccount", "UserID");
        }
    }
}
