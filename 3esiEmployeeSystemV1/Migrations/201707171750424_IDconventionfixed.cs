namespace _3esiEmployeeSystemV1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IDconventionfixed : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Benefits", "BenefitTypeID", "dbo.BenefitTypes");
            DropForeignKey("dbo.Compensations", "CurrencyID", "dbo.Currencies");
            DropForeignKey("dbo.Benefits", "CurrencyID", "dbo.Currencies");
            DropForeignKey("dbo.Compensations", "CompensationTypeID", "dbo.CompensationTypes");
            DropForeignKey("dbo.Careers", "BudgetAreaID", "dbo.BudgetAreas");
            DropForeignKey("dbo.Careers", "DepartmentID", "dbo.Departments");
            DropForeignKey("dbo.Trainings", "TrainingCategoryID", "dbo.TrainingCategories");
            DropForeignKey("dbo.Trainings", "TrainingTypeID", "dbo.TrainingTypes");
            DropPrimaryKey("dbo.BenefitTypes");
            DropPrimaryKey("dbo.Currencies");
            DropPrimaryKey("dbo.CompensationTypes");
            DropPrimaryKey("dbo.BudgetAreas");
            DropPrimaryKey("dbo.Departments");
            DropPrimaryKey("dbo.TrainingCategories");
            DropPrimaryKey("dbo.TrainingTypes");
            DropColumn("dbo.Benefits", "BenefitDateStart");
            DropColumn("dbo.Benefits", "BenefitComment");
            DropColumn("dbo.BenefitTypes", "BenefitTypeID");
            DropColumn("dbo.Currencies", "CurrencyID");

            DropColumn("dbo.CompensationTypes", "CompensationTypeID");
            DropColumn("dbo.Careers", "StartDate");
            DropColumn("dbo.BudgetAreas", "BudgetAreaID");

            DropColumn("dbo.Departments", "DepartmentID");

            DropColumn("dbo.TrainingCategories", "TrainingCategoryID");
            DropColumn("dbo.TrainingTypes", "TrainingTypeID");
            AddColumn("dbo.Benefits", "EffectiveDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Benefits", "EndDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Benefits", "Comment", c => c.String());
            AddColumn("dbo.BenefitTypes", "ID", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Currencies", "ID", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Currencies", "Name", c => c.String());
            AddColumn("dbo.Compensations", "EndDate", c => c.DateTime());
            AddColumn("dbo.CompensationTypes", "ID", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Careers", "EffectiveDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.BudgetAreas", "ID", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.BudgetAreas", "Name", c => c.String(maxLength: 50));
            AddColumn("dbo.Departments", "ID", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Departments", "Name", c => c.String(maxLength: 50));
            AddColumn("dbo.Status", "EndDate", c => c.DateTime());
            AddColumn("dbo.TrainingCategories", "ID", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.TrainingTypes", "ID", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.BenefitTypes", "ID");
            AddPrimaryKey("dbo.Currencies", "ID");
            AddPrimaryKey("dbo.CompensationTypes", "ID");
            AddPrimaryKey("dbo.BudgetAreas", "ID");
            AddPrimaryKey("dbo.Departments", "ID");
            AddPrimaryKey("dbo.TrainingCategories", "ID");
            AddPrimaryKey("dbo.TrainingTypes", "ID");
            DropColumn("dbo.Currencies", "CurrencyName");
            DropColumn("dbo.BudgetAreas", "BudgetAreaName");
            DropColumn("dbo.Departments", "DepartmentName");
            AddForeignKey("dbo.Benefits", "BenefitTypeID", "dbo.BenefitTypes", "ID", cascadeDelete: true);
            AddForeignKey("dbo.Compensations", "CurrencyID", "dbo.Currencies", "ID", cascadeDelete: true);
            AddForeignKey("dbo.Benefits", "CurrencyID", "dbo.Currencies", "ID", cascadeDelete: true);
            AddForeignKey("dbo.Compensations", "CompensationTypeID", "dbo.CompensationTypes", "ID", cascadeDelete: true);
            AddForeignKey("dbo.Careers", "BudgetAreaID", "dbo.BudgetAreas", "ID", cascadeDelete: true);
            AddForeignKey("dbo.Careers", "DepartmentID", "dbo.Departments", "ID", cascadeDelete: true);
            AddForeignKey("dbo.Trainings", "TrainingCategoryID", "dbo.TrainingCategories", "ID", cascadeDelete: true);
            AddForeignKey("dbo.Trainings", "TrainingTypeID", "dbo.TrainingTypes", "ID", cascadeDelete: true);

        }
        
        public override void Down()
        {
            AddColumn("dbo.TrainingTypes", "TrainingTypeID", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.TrainingCategories", "TrainingCategoryID", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Departments", "DepartmentName", c => c.String(maxLength: 50));
            AddColumn("dbo.Departments", "DepartmentID", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.BudgetAreas", "BudgetAreaName", c => c.String(maxLength: 50));
            AddColumn("dbo.BudgetAreas", "BudgetAreaID", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Careers", "StartDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.CompensationTypes", "CompensationTypeID", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Currencies", "CurrencyName", c => c.String());
            AddColumn("dbo.Currencies", "CurrencyID", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.BenefitTypes", "BenefitTypeID", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Benefits", "BenefitComment", c => c.String());
            AddColumn("dbo.Benefits", "BenefitDateStart", c => c.DateTime(nullable: false));
            DropForeignKey("dbo.Trainings", "TrainingTypeID", "dbo.TrainingTypes");
            DropForeignKey("dbo.Trainings", "TrainingCategoryID", "dbo.TrainingCategories");
            DropForeignKey("dbo.Careers", "DepartmentID", "dbo.Departments");
            DropForeignKey("dbo.Careers", "BudgetAreaID", "dbo.BudgetAreas");
            DropForeignKey("dbo.Compensations", "CompensationTypeID", "dbo.CompensationTypes");
            DropForeignKey("dbo.Benefits", "CurrencyID", "dbo.Currencies");
            DropForeignKey("dbo.Compensations", "CurrencyID", "dbo.Currencies");
            DropForeignKey("dbo.Benefits", "BenefitTypeID", "dbo.BenefitTypes");
            DropPrimaryKey("dbo.TrainingTypes");
            DropPrimaryKey("dbo.TrainingCategories");
            DropPrimaryKey("dbo.Departments");
            DropPrimaryKey("dbo.BudgetAreas");
            DropPrimaryKey("dbo.CompensationTypes");
            DropPrimaryKey("dbo.Currencies");
            DropPrimaryKey("dbo.BenefitTypes");
            DropColumn("dbo.TrainingTypes", "ID");
            DropColumn("dbo.TrainingCategories", "ID");
            DropColumn("dbo.Status", "EndDate");
            DropColumn("dbo.Departments", "Name");
            DropColumn("dbo.Departments", "ID");
            DropColumn("dbo.BudgetAreas", "Name");
            DropColumn("dbo.BudgetAreas", "ID");
            DropColumn("dbo.Careers", "EffectiveDate");
            DropColumn("dbo.CompensationTypes", "ID");
            DropColumn("dbo.Compensations", "EndDate");
            DropColumn("dbo.Currencies", "Name");
            DropColumn("dbo.Currencies", "ID");
            DropColumn("dbo.BenefitTypes", "ID");
            DropColumn("dbo.Benefits", "Comment");
            DropColumn("dbo.Benefits", "EndDate");
            DropColumn("dbo.Benefits", "EffectiveDate");
            AddPrimaryKey("dbo.TrainingTypes", "TrainingTypeID");
            AddPrimaryKey("dbo.TrainingCategories", "TrainingCategoryID");
            AddPrimaryKey("dbo.Departments", "DepartmentID");
            AddPrimaryKey("dbo.BudgetAreas", "BudgetAreaID");
            AddPrimaryKey("dbo.CompensationTypes", "CompensationTypeID");
            AddPrimaryKey("dbo.Currencies", "CurrencyID");
            AddPrimaryKey("dbo.BenefitTypes", "BenefitTypeID");
            AddForeignKey("dbo.Trainings", "TrainingTypeID", "dbo.TrainingTypes", "TrainingTypeID", cascadeDelete: true);
            AddForeignKey("dbo.Trainings", "TrainingCategoryID", "dbo.TrainingCategories", "TrainingCategoryID", cascadeDelete: true);
            AddForeignKey("dbo.Careers", "DepartmentID", "dbo.Departments", "DepartmentID", cascadeDelete: true);
            AddForeignKey("dbo.Careers", "BudgetAreaID", "dbo.BudgetAreas", "BudgetAreaID", cascadeDelete: true);
            AddForeignKey("dbo.Compensations", "CompensationTypeID", "dbo.CompensationTypes", "CompensationTypeID", cascadeDelete: true);
            AddForeignKey("dbo.Benefits", "CurrencyID", "dbo.Currencies", "CurrencyID", cascadeDelete: true);
            AddForeignKey("dbo.Compensations", "CurrencyID", "dbo.Currencies", "CurrencyID", cascadeDelete: true);
            AddForeignKey("dbo.Benefits", "BenefitTypeID", "dbo.BenefitTypes", "BenefitTypeID", cascadeDelete: true);
        }
    }
}
