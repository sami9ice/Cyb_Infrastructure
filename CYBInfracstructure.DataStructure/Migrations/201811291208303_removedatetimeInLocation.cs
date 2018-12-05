namespace CYBInfracstructure.DataStructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removedatetimeInLocation : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Location", "Date", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Location", "Date", c => c.DateTime(nullable: false));
        }
    }
}
