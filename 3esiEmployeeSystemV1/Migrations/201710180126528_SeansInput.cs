namespace _3esiEmployeeSystemV1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeansInput : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Employees", "Citizenship", c => c.String());
            AlterColumn("dbo.Employees", "ProvinceState", c => c.String());
            AlterColumn("dbo.Employees", "MobilePhone", c => c.String());
            AlterColumn("dbo.Employees", "YearsIndustryService", c => c.Int());
            AlterColumn("dbo.BudgetAreas", "Name", c => c.String());
            AlterColumn("dbo.Departments", "Name", c => c.String());
            AlterColumn("dbo.Status", "PayRollNumber", c => c.String());
            AlterColumn("dbo.HeritageCompanies", "Name", c => c.String());
            AlterColumn("dbo.LegalCompanies", "Name", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.LegalCompanies", "Name", c => c.String(maxLength: 50));
            AlterColumn("dbo.HeritageCompanies", "Name", c => c.String(maxLength: 50));
            AlterColumn("dbo.Status", "PayRollNumber", c => c.String(nullable: false));
            AlterColumn("dbo.Departments", "Name", c => c.String(maxLength: 50));
            AlterColumn("dbo.BudgetAreas", "Name", c => c.String(maxLength: 50));
            AlterColumn("dbo.Employees", "YearsIndustryService", c => c.Int(nullable: false));
            AlterColumn("dbo.Employees", "MobilePhone", c => c.String(nullable: false));
            AlterColumn("dbo.Employees", "ProvinceState", c => c.String(nullable: false));
            AlterColumn("dbo.Employees", "Citizenship", c => c.String(nullable: false));
        }
    }
}
