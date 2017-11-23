namespace _3esiEmployeeSystemV1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class benefitidfix2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Benefits", "Currency_CurrencyID", "dbo.Currencies");
            DropIndex("dbo.Benefits", new[] { "Currency_CurrencyID" });
            RenameColumn(table: "dbo.Benefits", name: "Currency_CurrencyID", newName: "CurrencyID");
            DropPrimaryKey("dbo.Benefits");
            
            AlterColumn("dbo.Benefits", "CurrencyID", c => c.Int(nullable: false));
            
            CreateIndex("dbo.Benefits", "CurrencyID");
            AddForeignKey("dbo.Benefits", "CurrencyID", "dbo.Currencies", "CurrencyID", cascadeDelete: true);
            DropColumn("dbo.Benefits", "ID");
            AddColumn("dbo.Benefits", "BenefitID", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Benefits", "BenefitID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Benefits", "ID", c => c.Int(nullable: false, identity: true));
            DropForeignKey("dbo.Benefits", "CurrencyID", "dbo.Currencies");
            DropIndex("dbo.Benefits", new[] { "CurrencyID" });
            DropPrimaryKey("dbo.Benefits");
            AlterColumn("dbo.Benefits", "CurrencyID", c => c.Int());
            DropColumn("dbo.Benefits", "BenefitID");
            AddPrimaryKey("dbo.Benefits", "ID");
            RenameColumn(table: "dbo.Benefits", name: "CurrencyID", newName: "Currency_CurrencyID");
            CreateIndex("dbo.Benefits", "Currency_CurrencyID");
            AddForeignKey("dbo.Benefits", "Currency_CurrencyID", "dbo.Currencies", "CurrencyID");
        }
    }
}
