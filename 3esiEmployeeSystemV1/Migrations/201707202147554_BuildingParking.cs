namespace _3esiEmployeeSystemV1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BuildingParking : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Buildings", "Name", c => c.String());
            AddColumn("dbo.Parkings", "Company", c => c.String());
            AddColumn("dbo.Parkings", "ContactNumber", c => c.String());
            AlterColumn("dbo.Buildings", "ContactNumber", c => c.String());
            DropColumn("dbo.Buildings", "BuildingName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Buildings", "BuildingName", c => c.String());
            AlterColumn("dbo.Buildings", "ContactNumber", c => c.Int(nullable: false));
            DropColumn("dbo.Parkings", "ContactNumber");
            DropColumn("dbo.Parkings", "Company");
            DropColumn("dbo.Buildings", "Name");
        }
    }
}
