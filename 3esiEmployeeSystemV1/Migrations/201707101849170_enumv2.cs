namespace _3esiEmployeeSystemV1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class enumv2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BenefitTypes",
                c => new
                    {
                        BenefitTypeID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Abbreviation = c.String(),
                    })
                .PrimaryKey(t => t.BenefitTypeID);
            
            AddColumn("dbo.Benefits", "BenefitTypeID", c => c.Int(nullable: false));
            CreateIndex("dbo.Benefits", "BenefitTypeID");
            AddForeignKey("dbo.Benefits", "BenefitTypeID", "dbo.BenefitTypes", "BenefitTypeID", cascadeDelete: true);
            DropColumn("dbo.Benefits", "BenefitType");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Benefits", "BenefitType", c => c.Int(nullable: false));
            DropForeignKey("dbo.Benefits", "BenefitTypeID", "dbo.BenefitTypes");
            DropIndex("dbo.Benefits", new[] { "BenefitTypeID" });
            DropColumn("dbo.Benefits", "BenefitTypeID");
            DropTable("dbo.BenefitTypes");
        }
    }
}
