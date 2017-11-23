namespace _3esiEmployeeSystemV1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeansInput2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.BudgetAreas", "Name", c => c.String(maxLength: 50));
            AlterColumn("dbo.Departments", "Name", c => c.String(maxLength: 50));
            AlterColumn("dbo.HeritageCompanies", "Name", c => c.String(maxLength: 50));
            AlterColumn("dbo.LegalCompanies", "Name", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.LegalCompanies", "Name", c => c.String());
            AlterColumn("dbo.HeritageCompanies", "Name", c => c.String());
            AlterColumn("dbo.Departments", "Name", c => c.String());
            AlterColumn("dbo.BudgetAreas", "Name", c => c.String());
        }
    }
}
