namespace _3esiEmployeeSystemV1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class benefitIDchanged : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Benefits");
            AlterColumn("dbo.Benefits", "BenefitID", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Benefits", "BenefitID");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Benefits");
            AlterColumn("dbo.Benefits", "BenefitID", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Benefits", "BenefitID");
        }
    }
}
