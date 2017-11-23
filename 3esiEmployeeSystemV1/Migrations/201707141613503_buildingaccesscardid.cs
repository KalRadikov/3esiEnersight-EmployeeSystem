namespace _3esiEmployeeSystemV1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class buildingaccesscardid : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.BuildingAccesses", "CardIDNumber", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.BuildingAccesses", "CardIDNumber", c => c.Int(nullable: false));
        }
    }
}
