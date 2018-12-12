namespace CYBInfracstructure.DataStructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class rolename : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.UsersInRoles", "RoleId", "dbo.Role");
            DropIndex("dbo.UsersInRoles", new[] { "RoleId" });
            RenameColumn(table: "dbo.UsersInRoles", name: "RoleId", newName: "Role_RoleId");
            AddColumn("dbo.UsersInRoles", "RoleName", c => c.String());
            AlterColumn("dbo.UsersInRoles", "Role_RoleId", c => c.Int());
            CreateIndex("dbo.UsersInRoles", "Role_RoleId");
            AddForeignKey("dbo.UsersInRoles", "Role_RoleId", "dbo.Role", "RoleId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UsersInRoles", "Role_RoleId", "dbo.Role");
            DropIndex("dbo.UsersInRoles", new[] { "Role_RoleId" });
            AlterColumn("dbo.UsersInRoles", "Role_RoleId", c => c.Int(nullable: false));
            DropColumn("dbo.UsersInRoles", "RoleName");
            RenameColumn(table: "dbo.UsersInRoles", name: "Role_RoleId", newName: "RoleId");
            CreateIndex("dbo.UsersInRoles", "RoleId");
            AddForeignKey("dbo.UsersInRoles", "RoleId", "dbo.Role", "RoleId", cascadeDelete: true);
        }
    }
}
