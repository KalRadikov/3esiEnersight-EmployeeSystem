namespace _3esiEmployeeSystemV1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LocaltoSQL : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CompensationTypes", "Name", c => c.String());
            AddColumn("dbo.CompensationTypes", "Abbreviation", c => c.String());
            DropColumn("dbo.CompensationTypes", "CompensationTypeName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CompensationTypes", "CompensationTypeName", c => c.String());
            DropColumn("dbo.CompensationTypes", "Abbreviation");
            DropColumn("dbo.CompensationTypes", "Name");
        }
    }
}
