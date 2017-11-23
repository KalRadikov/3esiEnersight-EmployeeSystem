namespace _3esiEmployeeSystemV1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeansInput3 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Benefits", "BenefitPlan", c => c.String(maxLength: 32));
            AlterColumn("dbo.Employees", "LastName", c => c.String(nullable: false, maxLength: 32));
            AlterColumn("dbo.Employees", "FirstName", c => c.String(nullable: false, maxLength: 32));
            AlterColumn("dbo.Employees", "MiddleName", c => c.String(maxLength: 32));
            AlterColumn("dbo.Employees", "Citizenship", c => c.String(maxLength: 32));
            AlterColumn("dbo.Employees", "Address1", c => c.String(nullable: false, maxLength: 32));
            AlterColumn("dbo.Employees", "Address2", c => c.String(maxLength: 32));
            AlterColumn("dbo.Employees", "City", c => c.String(nullable: false, maxLength: 32));
            AlterColumn("dbo.Employees", "ProvinceState", c => c.String(maxLength: 32));
            AlterColumn("dbo.Employees", "Country", c => c.String(nullable: false, maxLength: 32));
            AlterColumn("dbo.Employees", "PostalZip", c => c.String(maxLength: 32));
            AlterColumn("dbo.Employees", "HomePhone", c => c.String(maxLength: 32));
            AlterColumn("dbo.Employees", "MobilePhone", c => c.String(maxLength: 32));
            AlterColumn("dbo.Employees", "OfficePhone", c => c.String(maxLength: 32));
            AlterColumn("dbo.Employees", "EmergencyContactName", c => c.String(maxLength: 32));
            AlterColumn("dbo.Employees", "EmergencyContactRelationship", c => c.String(maxLength: 32));
            AlterColumn("dbo.Employees", "EmergencyContactNumber", c => c.String(maxLength: 32));
            AlterColumn("dbo.Buildings", "Name", c => c.String(maxLength: 32));
            AlterColumn("dbo.Buildings", "Address", c => c.String(maxLength: 32));
            AlterColumn("dbo.Buildings", "Company", c => c.String(maxLength: 32));
            AlterColumn("dbo.Buildings", "ContactNumber", c => c.String(maxLength: 32));
            AlterColumn("dbo.Status", "PayRollNumber", c => c.String(maxLength: 32));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Status", "PayRollNumber", c => c.String(maxLength: 100));
            AlterColumn("dbo.Buildings", "ContactNumber", c => c.String(maxLength: 100));
            AlterColumn("dbo.Buildings", "Company", c => c.String(maxLength: 100));
            AlterColumn("dbo.Buildings", "Address", c => c.String(maxLength: 100));
            AlterColumn("dbo.Buildings", "Name", c => c.String(maxLength: 100));
            AlterColumn("dbo.Employees", "EmergencyContactNumber", c => c.String(maxLength: 100));
            AlterColumn("dbo.Employees", "EmergencyContactRelationship", c => c.String(maxLength: 100));
            AlterColumn("dbo.Employees", "EmergencyContactName", c => c.String(maxLength: 100));
            AlterColumn("dbo.Employees", "OfficePhone", c => c.String(maxLength: 100));
            AlterColumn("dbo.Employees", "MobilePhone", c => c.String(maxLength: 100));
            AlterColumn("dbo.Employees", "HomePhone", c => c.String(maxLength: 100));
            AlterColumn("dbo.Employees", "PostalZip", c => c.String(maxLength: 100));
            AlterColumn("dbo.Employees", "Country", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Employees", "ProvinceState", c => c.String(maxLength: 100));
            AlterColumn("dbo.Employees", "City", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Employees", "Address2", c => c.String(maxLength: 100));
            AlterColumn("dbo.Employees", "Address1", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Employees", "Citizenship", c => c.String(maxLength: 100));
            AlterColumn("dbo.Employees", "MiddleName", c => c.String(maxLength: 100));
            AlterColumn("dbo.Employees", "FirstName", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Employees", "LastName", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Benefits", "BenefitPlan", c => c.String(maxLength: 100));
        }
    }
}
