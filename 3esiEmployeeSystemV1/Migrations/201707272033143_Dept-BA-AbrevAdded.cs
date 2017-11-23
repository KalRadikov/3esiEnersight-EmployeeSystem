namespace _3esiEmployeeSystemV1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeptBAAbrevAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BudgetAreas", "Abbreviation", c => c.String());
            AddColumn("dbo.Departments", "Abbreviation", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Departments", "Abbreviation");
            DropColumn("dbo.BudgetAreas", "Abbreviation");
        }
    }
}
