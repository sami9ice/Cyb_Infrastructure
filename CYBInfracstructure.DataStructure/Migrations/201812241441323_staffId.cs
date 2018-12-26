namespace CYBInfracstructure.DataStructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class staffId : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.UserAccount", "StaffID", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.UserAccount", "StaffID", c => c.String(nullable: false));
        }
    }
}
