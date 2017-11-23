namespace _3esiEmployeeSystemV1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class enumchanged : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Status", "HeritageCompanyID", "dbo.HeritageCompanies");
            DropPrimaryKey("dbo.HeritageCompanies");
            CreateTable(
                "dbo.Currencies",
                c => new
                    {
                        CurrencyID = c.Int(nullable: false, identity: true),
                        CurrencyName = c.String(),
                    })
                .PrimaryKey(t => t.CurrencyID);
            
            CreateTable(
                "dbo.CompensationTypes",
                c => new
                    {
                        CompensationTypeID = c.Int(nullable: false, identity: true),
                        CompensationTypeName = c.String(),
                    })
                .PrimaryKey(t => t.CompensationTypeID);
            
            CreateTable(
                "dbo.EmployeeStatus",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Abbreviation = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.EmployeeTypes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Abbreviation = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.OverTimeStatus",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Abbreviation = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.UnionStatus",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Abbreviation = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.Benefits", "Currency_CurrencyID", c => c.Int());
            AddColumn("dbo.Compensations", "EffectiveDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Compensations", "CompensationTypeID", c => c.Int(nullable: false));
            AddColumn("dbo.Compensations", "CurrencyID", c => c.Int(nullable: false));
            AddColumn("dbo.Status", "EffectiveDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Status", "EmployeeStatusID", c => c.Int(nullable: false));
            AddColumn("dbo.Status", "EmployeeTypeID", c => c.Int(nullable: false));
            AddColumn("dbo.Status", "OverTimeStatusID", c => c.Int(nullable: false));
            AddColumn("dbo.Status", "UnionStatusID", c => c.Int(nullable: false));
            AlterColumn("dbo.HeritageCompanies", "HeritageCompanyID", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.HeritageCompanies", "HeritageCompanyID");
            CreateIndex("dbo.Benefits", "Currency_CurrencyID");
            CreateIndex("dbo.Compensations", "CompensationTypeID");
            CreateIndex("dbo.Compensations", "CurrencyID");
            CreateIndex("dbo.Status", "EmployeeStatusID");
            CreateIndex("dbo.Status", "EmployeeTypeID");
            CreateIndex("dbo.Status", "OverTimeStatusID");
            CreateIndex("dbo.Status", "UnionStatusID");
            AddForeignKey("dbo.Compensations", "CompensationTypeID", "dbo.CompensationTypes", "CompensationTypeID", cascadeDelete: true);
            AddForeignKey("dbo.Compensations", "CurrencyID", "dbo.Currencies", "CurrencyID", cascadeDelete: true);
            AddForeignKey("dbo.Status", "EmployeeStatusID", "dbo.EmployeeStatus", "ID", cascadeDelete: true);
            AddForeignKey("dbo.Status", "EmployeeTypeID", "dbo.EmployeeTypes", "ID", cascadeDelete: true);
            AddForeignKey("dbo.Status", "OverTimeStatusID", "dbo.OverTimeStatus", "ID", cascadeDelete: true);
            AddForeignKey("dbo.Status", "UnionStatusID", "dbo.UnionStatus", "ID", cascadeDelete: true);
            AddForeignKey("dbo.Benefits", "Currency_CurrencyID", "dbo.Currencies", "CurrencyID");
            AddForeignKey("dbo.Status", "HeritageCompanyID", "dbo.HeritageCompanies", "HeritageCompanyID", cascadeDelete: true);
            DropColumn("dbo.Benefits", "Currency");
            DropColumn("dbo.Compensations", "CompensationDateStart");
            DropColumn("dbo.Compensations", "CompensationType");
            DropColumn("dbo.Compensations", "Currency");
            DropColumn("dbo.Status", "WhenCreated");
            DropColumn("dbo.Status", "Employee_Status");
            DropColumn("dbo.Status", "EmployeeType");
            DropColumn("dbo.Status", "OverTimeStatus");
            DropColumn("dbo.Status", "UnionStatus");
            DropColumn("dbo.HeritageCompanies", "ID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.HeritageCompanies", "ID", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Status", "UnionStatus", c => c.Int(nullable: false));
            AddColumn("dbo.Status", "OverTimeStatus", c => c.Int(nullable: false));
            AddColumn("dbo.Status", "EmployeeType", c => c.Int(nullable: false));
            AddColumn("dbo.Status", "Employee_Status", c => c.Int(nullable: false));
            AddColumn("dbo.Status", "WhenCreated", c => c.DateTime(nullable: false));
            AddColumn("dbo.Compensations", "Currency", c => c.Int(nullable: false));
            AddColumn("dbo.Compensations", "CompensationType", c => c.Int(nullable: false));
            AddColumn("dbo.Compensations", "CompensationDateStart", c => c.DateTime(nullable: false));
            AddColumn("dbo.Benefits", "Currency", c => c.Int(nullable: false));
            DropForeignKey("dbo.Status", "HeritageCompanyID", "dbo.HeritageCompanies");
            DropForeignKey("dbo.Benefits", "Currency_CurrencyID", "dbo.Currencies");
            DropForeignKey("dbo.Status", "UnionStatusID", "dbo.UnionStatus");
            DropForeignKey("dbo.Status", "OverTimeStatusID", "dbo.OverTimeStatus");
            DropForeignKey("dbo.Status", "EmployeeTypeID", "dbo.EmployeeTypes");
            DropForeignKey("dbo.Status", "EmployeeStatusID", "dbo.EmployeeStatus");
            DropForeignKey("dbo.Compensations", "CurrencyID", "dbo.Currencies");
            DropForeignKey("dbo.Compensations", "CompensationTypeID", "dbo.CompensationTypes");
            DropIndex("dbo.Status", new[] { "UnionStatusID" });
            DropIndex("dbo.Status", new[] { "OverTimeStatusID" });
            DropIndex("dbo.Status", new[] { "EmployeeTypeID" });
            DropIndex("dbo.Status", new[] { "EmployeeStatusID" });
            DropIndex("dbo.Compensations", new[] { "CurrencyID" });
            DropIndex("dbo.Compensations", new[] { "CompensationTypeID" });
            DropIndex("dbo.Benefits", new[] { "Currency_CurrencyID" });
            DropPrimaryKey("dbo.HeritageCompanies");
            AlterColumn("dbo.HeritageCompanies", "HeritageCompanyID", c => c.Int(nullable: false));
            DropColumn("dbo.Status", "UnionStatusID");
            DropColumn("dbo.Status", "OverTimeStatusID");
            DropColumn("dbo.Status", "EmployeeTypeID");
            DropColumn("dbo.Status", "EmployeeStatusID");
            DropColumn("dbo.Status", "EffectiveDate");
            DropColumn("dbo.Compensations", "CurrencyID");
            DropColumn("dbo.Compensations", "CompensationTypeID");
            DropColumn("dbo.Compensations", "EffectiveDate");
            DropColumn("dbo.Benefits", "Currency_CurrencyID");
            DropTable("dbo.UnionStatus");
            DropTable("dbo.OverTimeStatus");
            DropTable("dbo.EmployeeTypes");
            DropTable("dbo.EmployeeStatus");
            DropTable("dbo.CompensationTypes");
            DropTable("dbo.Currencies");
            AddPrimaryKey("dbo.HeritageCompanies", "ID");
            AddForeignKey("dbo.Status", "HeritageCompanyID", "dbo.HeritageCompanies", "ID", cascadeDelete: true);
        }
    }
}
