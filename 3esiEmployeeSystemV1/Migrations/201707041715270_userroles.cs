namespace _3esiEmployeeSystemV1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class userroles : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Benefits",
                c => new
                    {
                        BenefitID = c.Int(nullable: false),
                        EmployeeID = c.Int(nullable: false),
                        BenefitDateStart = c.DateTime(nullable: false),
                        BenefitPlan = c.String(),
                        BenefitType = c.Int(nullable: false),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Currency = c.Int(nullable: false),
                        BenefitComment = c.String(),
                    })
                .PrimaryKey(t => t.BenefitID)
                .ForeignKey("dbo.Employees", t => t.EmployeeID, cascadeDelete: true)
                .Index(t => t.EmployeeID);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        EmployeeID = c.Int(nullable: false, identity: true),
                        LastName = c.String(nullable: false),
                        FirstName = c.String(nullable: false),
                        MiddleName = c.String(),
                        Gender = c.Int(nullable: false),
                        BirthDate = c.DateTime(nullable: false),
                        Citizenship = c.String(nullable: false),
                        Address1 = c.String(nullable: false),
                        Address2 = c.String(),
                        City = c.String(nullable: false),
                        ProvinceState = c.String(nullable: false),
                        Country = c.String(nullable: false),
                        PostalZip = c.String(),
                        HomePhone = c.String(),
                        MobilePhone = c.String(nullable: false),
                        OfficePhone = c.String(),
                        HireDate = c.DateTime(nullable: false),
                        ContractEndDate = c.DateTime(),
                        TerminationDate = c.DateTime(),
                        EmergencyContactName = c.String(),
                        EmergencyContactRelationship = c.String(),
                        EmergencyContactNumber = c.String(),
                        YearsIndustryService = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.EmployeeID);
            
            CreateTable(
                "dbo.Accesses",
                c => new
                    {
                        AccessID = c.Int(nullable: false, identity: true),
                        Employee_EmployeeID = c.Int(),
                    })
                .PrimaryKey(t => t.AccessID)
                .ForeignKey("dbo.Employees", t => t.Employee_EmployeeID)
                .Index(t => t.Employee_EmployeeID);
            
            CreateTable(
                "dbo.Careers",
                c => new
                    {
                        CareerID = c.Int(nullable: false, identity: true),
                        EmployeeID = c.Int(nullable: false),
                        Title = c.String(),
                        DepartmentID = c.Int(nullable: false),
                        BudgetAreaID = c.Int(nullable: false),
                        Supervisor = c.String(),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.CareerID)
                .ForeignKey("dbo.BudgetAreas", t => t.BudgetAreaID, cascadeDelete: true)
                .ForeignKey("dbo.Departments", t => t.DepartmentID, cascadeDelete: true)
                .ForeignKey("dbo.Employees", t => t.EmployeeID, cascadeDelete: true)
                .Index(t => t.EmployeeID)
                .Index(t => t.DepartmentID)
                .Index(t => t.BudgetAreaID);
            
            CreateTable(
                "dbo.BudgetAreas",
                c => new
                    {
                        BudgetAreaID = c.Int(nullable: false, identity: true),
                        BudgetAreaName = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.BudgetAreaID);
            
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        DepartmentID = c.Int(nullable: false, identity: true),
                        DepartmentName = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.DepartmentID);
            
            CreateTable(
                "dbo.Compensations",
                c => new
                    {
                        CompensationID = c.Int(nullable: false, identity: true),
                        EmployeeID = c.Int(nullable: false),
                        CompensationDateStart = c.DateTime(nullable: false),
                        CompensationType = c.Int(nullable: false),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Currency = c.Int(nullable: false),
                        ExchangeRate = c.Double(nullable: false),
                        CompensationComment = c.String(),
                    })
                .PrimaryKey(t => t.CompensationID)
                .ForeignKey("dbo.Employees", t => t.EmployeeID, cascadeDelete: true)
                .Index(t => t.EmployeeID);
            
            CreateTable(
                "dbo.Status",
                c => new
                    {
                        StatusID = c.Int(nullable: false, identity: true),
                        EmployeeID = c.Int(nullable: false),
                        WhenCreated = c.DateTime(nullable: false),
                        HeritageCompanyID = c.Int(nullable: false),
                        LegalCompanyID = c.Int(nullable: false),
                        Employee_Status = c.Int(nullable: false),
                        EmployeeType = c.Int(nullable: false),
                        PercentFullTime = c.Double(nullable: false),
                        OverTimeStatus = c.Int(nullable: false),
                        UnionStatus = c.Int(nullable: false),
                        PayRollNumber = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.StatusID)
                .ForeignKey("dbo.Employees", t => t.EmployeeID, cascadeDelete: true)
                .ForeignKey("dbo.HeritageCompanies", t => t.HeritageCompanyID, cascadeDelete: true)
                .ForeignKey("dbo.LegalCompanies", t => t.LegalCompanyID, cascadeDelete: true)
                .Index(t => t.EmployeeID)
                .Index(t => t.HeritageCompanyID)
                .Index(t => t.LegalCompanyID);
            
            CreateTable(
                "dbo.HeritageCompanies",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        HeritageCompanyID = c.Int(nullable: false),
                        HeritageCompanyName = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.LegalCompanies",
                c => new
                    {
                        LegalCompanyID = c.Int(nullable: false, identity: true),
                        LegalCompanyName = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.LegalCompanyID);
            
            CreateTable(
                "dbo.ParkingAccesses",
                c => new
                    {
                        ParkingAccessID = c.Int(nullable: false, identity: true),
                        EmployeeID = c.Int(nullable: false),
                        ParkingID = c.Int(nullable: false),
                        EffectiveDate = c.DateTime(nullable: false),
                        CarModel = c.String(),
                        PlateNumber = c.String(),
                    })
                .PrimaryKey(t => t.ParkingAccessID)
                .ForeignKey("dbo.Employees", t => t.EmployeeID, cascadeDelete: true)
                .ForeignKey("dbo.Parkings", t => t.ParkingID, cascadeDelete: true)
                .Index(t => t.EmployeeID)
                .Index(t => t.ParkingID);
            
            CreateTable(
                "dbo.Parkings",
                c => new
                    {
                        ParkingID = c.Int(nullable: false, identity: true),
                        Address = c.String(),
                        SpacesAvailable = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ParkingID);
            
            CreateTable(
                "dbo.Trainings",
                c => new
                    {
                        TrainingID = c.Int(nullable: false, identity: true),
                        EmployeeID = c.Int(nullable: false),
                        CourseName = c.String(),
                        TrainingTypeID = c.Int(nullable: false),
                        TrainingCategoryID = c.Int(nullable: false),
                        OfferedBy = c.String(),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Feedback = c.String(),
                    })
                .PrimaryKey(t => t.TrainingID)
                .ForeignKey("dbo.TrainingCategories", t => t.TrainingCategoryID, cascadeDelete: true)
                .ForeignKey("dbo.TrainingTypes", t => t.TrainingTypeID, cascadeDelete: true)
                .ForeignKey("dbo.Employees", t => t.EmployeeID, cascadeDelete: true)
                .Index(t => t.EmployeeID)
                .Index(t => t.TrainingTypeID)
                .Index(t => t.TrainingCategoryID);
            
            CreateTable(
                "dbo.TrainingCategories",
                c => new
                    {
                        TrainingCategoryID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.TrainingCategoryID);
            
            CreateTable(
                "dbo.TrainingTypes",
                c => new
                    {
                        TrainingTypeID = c.Int(nullable: false, identity: true),
                        Type = c.String(),
                    })
                .PrimaryKey(t => t.TrainingTypeID);
            
            CreateTable(
                "dbo.BuildingAccesses",
                c => new
                    {
                        BuildingAccessID = c.Int(nullable: false, identity: true),
                        EmployeeID = c.Int(nullable: false),
                        BuildingID = c.Int(nullable: false),
                        EffectiveDate = c.DateTime(nullable: false),
                        CardIDNumber = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BuildingAccessID)
                .ForeignKey("dbo.Buildings", t => t.BuildingID, cascadeDelete: true)
                .ForeignKey("dbo.Employees", t => t.EmployeeID, cascadeDelete: true)
                .Index(t => t.EmployeeID)
                .Index(t => t.BuildingID);
            
            CreateTable(
                "dbo.Buildings",
                c => new
                    {
                        BuildingID = c.Int(nullable: false, identity: true),
                        BuildingName = c.String(),
                        Address = c.String(),
                        Company = c.String(),
                        ContactNumber = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BuildingID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BuildingAccesses", "EmployeeID", "dbo.Employees");
            DropForeignKey("dbo.BuildingAccesses", "BuildingID", "dbo.Buildings");
            DropForeignKey("dbo.Trainings", "EmployeeID", "dbo.Employees");
            DropForeignKey("dbo.Trainings", "TrainingTypeID", "dbo.TrainingTypes");
            DropForeignKey("dbo.Trainings", "TrainingCategoryID", "dbo.TrainingCategories");
            DropForeignKey("dbo.ParkingAccesses", "ParkingID", "dbo.Parkings");
            DropForeignKey("dbo.ParkingAccesses", "EmployeeID", "dbo.Employees");
            DropForeignKey("dbo.Status", "LegalCompanyID", "dbo.LegalCompanies");
            DropForeignKey("dbo.Status", "HeritageCompanyID", "dbo.HeritageCompanies");
            DropForeignKey("dbo.Status", "EmployeeID", "dbo.Employees");
            DropForeignKey("dbo.Compensations", "EmployeeID", "dbo.Employees");
            DropForeignKey("dbo.Careers", "EmployeeID", "dbo.Employees");
            DropForeignKey("dbo.Careers", "DepartmentID", "dbo.Departments");
            DropForeignKey("dbo.Careers", "BudgetAreaID", "dbo.BudgetAreas");
            DropForeignKey("dbo.Benefits", "EmployeeID", "dbo.Employees");
            DropForeignKey("dbo.Accesses", "Employee_EmployeeID", "dbo.Employees");
            DropIndex("dbo.BuildingAccesses", new[] { "BuildingID" });
            DropIndex("dbo.BuildingAccesses", new[] { "EmployeeID" });
            DropIndex("dbo.Trainings", new[] { "TrainingCategoryID" });
            DropIndex("dbo.Trainings", new[] { "TrainingTypeID" });
            DropIndex("dbo.Trainings", new[] { "EmployeeID" });
            DropIndex("dbo.ParkingAccesses", new[] { "ParkingID" });
            DropIndex("dbo.ParkingAccesses", new[] { "EmployeeID" });
            DropIndex("dbo.Status", new[] { "LegalCompanyID" });
            DropIndex("dbo.Status", new[] { "HeritageCompanyID" });
            DropIndex("dbo.Status", new[] { "EmployeeID" });
            DropIndex("dbo.Compensations", new[] { "EmployeeID" });
            DropIndex("dbo.Careers", new[] { "BudgetAreaID" });
            DropIndex("dbo.Careers", new[] { "DepartmentID" });
            DropIndex("dbo.Careers", new[] { "EmployeeID" });
            DropIndex("dbo.Accesses", new[] { "Employee_EmployeeID" });
            DropIndex("dbo.Benefits", new[] { "EmployeeID" });
            DropTable("dbo.Buildings");
            DropTable("dbo.BuildingAccesses");
            DropTable("dbo.TrainingTypes");
            DropTable("dbo.TrainingCategories");
            DropTable("dbo.Trainings");
            DropTable("dbo.Parkings");
            DropTable("dbo.ParkingAccesses");
            DropTable("dbo.LegalCompanies");
            DropTable("dbo.HeritageCompanies");
            DropTable("dbo.Status");
            DropTable("dbo.Compensations");
            DropTable("dbo.Departments");
            DropTable("dbo.BudgetAreas");
            DropTable("dbo.Careers");
            DropTable("dbo.Accesses");
            DropTable("dbo.Employees");
            DropTable("dbo.Benefits");
        }
    }
}
