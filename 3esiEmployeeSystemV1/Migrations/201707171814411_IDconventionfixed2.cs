namespace _3esiEmployeeSystemV1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IDconventionfixed2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TrainingTypes", "Name", c => c.String());
            DropColumn("dbo.TrainingTypes", "Type");
        }
        
        public override void Down()
        {
            AddColumn("dbo.TrainingTypes", "Type", c => c.String());
            DropColumn("dbo.TrainingTypes", "Name");
        }
    }
}
