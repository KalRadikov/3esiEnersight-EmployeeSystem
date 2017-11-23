namespace _3esiEmployeeSystemV1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeansInput6 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TrainingCategories", "Abbreviation", c => c.String(maxLength: 10));
            AddColumn("dbo.TrainingTypes", "Abbreviation", c => c.String(maxLength: 10));
        }
        
        public override void Down()
        {
            DropColumn("dbo.TrainingTypes", "Abbreviation");
            DropColumn("dbo.TrainingCategories", "Abbreviation");
        }
    }
}
