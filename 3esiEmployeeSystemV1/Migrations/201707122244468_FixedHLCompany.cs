namespace _3esiEmployeeSystemV1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixedHLCompany : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Status", "HeritageCompanyID", "dbo.HeritageCompanies");
            DropForeignKey("dbo.Status", "LegalCompanyID", "dbo.LegalCompanies");
            DropPrimaryKey("dbo.HeritageCompanies");
            DropPrimaryKey("dbo.LegalCompanies");
            DropColumn("dbo.HeritageCompanies", "HeritageCompanyID");
            DropColumn("dbo.LegalCompanies", "LegalCompanyID");
            AddColumn("dbo.HeritageCompanies", "ID", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.HeritageCompanies", "Name", c => c.String(maxLength: 50));
            AddColumn("dbo.HeritageCompanies", "Abbreviation", c => c.String());
            AddColumn("dbo.LegalCompanies", "ID", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.LegalCompanies", "Name", c => c.String(maxLength: 50));
            AddColumn("dbo.LegalCompanies", "Abbreviation", c => c.String());
            AddPrimaryKey("dbo.HeritageCompanies", "ID");
            AddPrimaryKey("dbo.LegalCompanies", "ID");
            AddForeignKey("dbo.Status", "HeritageCompanyID", "dbo.HeritageCompanies", "ID", cascadeDelete: true);
            AddForeignKey("dbo.Status", "LegalCompanyID", "dbo.LegalCompanies", "ID", cascadeDelete: true);

            DropColumn("dbo.HeritageCompanies", "HeritageCompanyName");

            DropColumn("dbo.LegalCompanies", "LegalCompanyName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.LegalCompanies", "LegalCompanyName", c => c.String(maxLength: 50));
            AddColumn("dbo.LegalCompanies", "LegalCompanyID", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.HeritageCompanies", "HeritageCompanyName", c => c.String(maxLength: 50));
            AddColumn("dbo.HeritageCompanies", "HeritageCompanyID", c => c.Int(nullable: false, identity: true));
            DropForeignKey("dbo.Status", "LegalCompanyID", "dbo.LegalCompanies");
            DropForeignKey("dbo.Status", "HeritageCompanyID", "dbo.HeritageCompanies");
            DropPrimaryKey("dbo.LegalCompanies");
            DropPrimaryKey("dbo.HeritageCompanies");
            DropColumn("dbo.LegalCompanies", "Abbreviation");
            DropColumn("dbo.LegalCompanies", "Name");
            DropColumn("dbo.LegalCompanies", "ID");
            DropColumn("dbo.HeritageCompanies", "Abbreviation");
            DropColumn("dbo.HeritageCompanies", "Name");
            DropColumn("dbo.HeritageCompanies", "ID");
            AddPrimaryKey("dbo.LegalCompanies", "LegalCompanyID");
            AddPrimaryKey("dbo.HeritageCompanies", "HeritageCompanyID");
            AddForeignKey("dbo.Status", "LegalCompanyID", "dbo.LegalCompanies", "LegalCompanyID", cascadeDelete: true);
            AddForeignKey("dbo.Status", "HeritageCompanyID", "dbo.HeritageCompanies", "HeritageCompanyID", cascadeDelete: true);
        }
    }
}
