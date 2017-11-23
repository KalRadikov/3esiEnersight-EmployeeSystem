namespace _3esiEmployeeSystemV1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IDconvention3 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Benefits", "EndDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Benefits", "EndDate", c => c.DateTime(nullable: false));
        }
    }
}
