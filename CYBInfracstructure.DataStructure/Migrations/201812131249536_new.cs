namespace CYBInfracstructure.DataStructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _new : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CredentialSetup",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        HostUsername = c.String(),
                        HostPassword = c.String(nullable: false),
                        ServerUsername = c.String(),
                        ServerPassword = c.String(nullable: false),
                        HostId = c.Int(nullable: false),
                        Date = c.String(),
                        InventoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Host", t => t.HostId, cascadeDelete: true)
                .ForeignKey("dbo.Inventory", t => t.InventoryId, cascadeDelete: true)
                .Index(t => t.HostId)
                .Index(t => t.InventoryId);
            
            CreateTable(
                "dbo.Host",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        HostName = c.String(),
                        IpAddress = c.String(),
                        Date = c.String(),
                        CPU = c.String(),
                        RAM = c.String(),
                        DiskSpace = c.String(),
                        OperatingSystem = c.String(),
                        Hypervisor = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Inventory",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ServerName = c.String(),
                        Date = c.String(),
                        DescriptionOfServicesOffered = c.String(),
                        HostName = c.String(),
                        PrimaryIP = c.String(),
                        SecondaryIP = c.String(),
                        Description = c.String(),
                        LocationId = c.Int(nullable: false),
                        HostId = c.Int(nullable: false),
                        UnitId = c.Int(nullable: false),
                        VLAN = c.String(),
                        Gateway = c.String(),
                        Environment = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Host", t => t.HostId, cascadeDelete: false)
                .ForeignKey("dbo.Unit", t => t.UnitId, cascadeDelete: true)
                .ForeignKey("dbo.Location", t => t.LocationId, cascadeDelete: true)
                .Index(t => t.LocationId)
                .Index(t => t.HostId)
                .Index(t => t.UnitId);
            
            CreateTable(
                "dbo.Location",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LocationName = c.String(),
                        Date = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Department",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DepartmentName = c.String(),
                        Date = c.String(),
                        IsActive = c.Boolean(nullable: false),
                        LocationId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Location", t => t.LocationId, cascadeDelete: true)
                .Index(t => t.LocationId);
            
            CreateTable(
                "dbo.Unit",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UnitName = c.String(),
                        Date = c.String(),
                        DepartmentId = c.Int(nullable: false),
                        LocationId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Department", t => t.DepartmentId, cascadeDelete: false)
                .ForeignKey("dbo.Location", t => t.LocationId, cascadeDelete: false)
                .Index(t => t.DepartmentId)
                .Index(t => t.LocationId);
            
            CreateTable(
                "dbo.Services",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Date = c.String(),
                        Description = c.String(),
                        IsActive = c.Boolean(nullable: false),
                        Port = c.String(),
                        URL = c.String(),
                        InventoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Inventory", t => t.InventoryId, cascadeDelete: true)
                .Index(t => t.InventoryId);
            
            CreateTable(
                "dbo.Role",
                c => new
                    {
                        RoleId = c.Int(nullable: false, identity: true),
                        RoleName = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.RoleId);
            
            CreateTable(
                "dbo.UsersInRoles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RoleId = c.Int(nullable: false),
                        UserAccountId = c.Int(nullable: false),
                        UserAccount_UserID = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Role", t => t.RoleId, cascadeDelete: false)
                .ForeignKey("dbo.UserAccount", t => t.UserAccount_UserID)
                .Index(t => t.RoleId)
                .Index(t => t.UserAccount_UserID);
            
            CreateTable(
                "dbo.UserAccount",
                c => new
                    {
                        UserID = c.Int(nullable: false, identity: true),
                        StaffID = c.String(nullable: false),
                        StaffName = c.String(nullable: false),
                        Email = c.String(),
                        Password = c.String(nullable: false),
                        ConfirmPassword = c.String(),
                        ResetPasswordCode = c.String(),
                    })
                .PrimaryKey(t => t.UserID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UsersInRoles", "UserAccount_UserID", "dbo.UserAccount");
            DropForeignKey("dbo.UsersInRoles", "RoleId", "dbo.Role");
            DropForeignKey("dbo.Services", "InventoryId", "dbo.Inventory");
            DropForeignKey("dbo.Inventory", "LocationId", "dbo.Location");
            DropForeignKey("dbo.Unit", "LocationId", "dbo.Location");
            DropForeignKey("dbo.Inventory", "UnitId", "dbo.Unit");
            DropForeignKey("dbo.Unit", "DepartmentId", "dbo.Department");
            DropForeignKey("dbo.Department", "LocationId", "dbo.Location");
            DropForeignKey("dbo.Inventory", "HostId", "dbo.Host");
            DropForeignKey("dbo.CredentialSetup", "InventoryId", "dbo.Inventory");
            DropForeignKey("dbo.CredentialSetup", "HostId", "dbo.Host");
            DropIndex("dbo.UsersInRoles", new[] { "UserAccount_UserID" });
            DropIndex("dbo.UsersInRoles", new[] { "RoleId" });
            DropIndex("dbo.Services", new[] { "InventoryId" });
            DropIndex("dbo.Unit", new[] { "LocationId" });
            DropIndex("dbo.Unit", new[] { "DepartmentId" });
            DropIndex("dbo.Department", new[] { "LocationId" });
            DropIndex("dbo.Inventory", new[] { "UnitId" });
            DropIndex("dbo.Inventory", new[] { "HostId" });
            DropIndex("dbo.Inventory", new[] { "LocationId" });
            DropIndex("dbo.CredentialSetup", new[] { "InventoryId" });
            DropIndex("dbo.CredentialSetup", new[] { "HostId" });
            DropTable("dbo.UserAccount");
            DropTable("dbo.UsersInRoles");
            DropTable("dbo.Role");
            DropTable("dbo.Services");
            DropTable("dbo.Unit");
            DropTable("dbo.Department");
            DropTable("dbo.Location");
            DropTable("dbo.Inventory");
            DropTable("dbo.Host");
            DropTable("dbo.CredentialSetup");
        }
    }
}
