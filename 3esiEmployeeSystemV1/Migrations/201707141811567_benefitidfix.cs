namespace _3esiEmployeeSystemV1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class benefitidfix : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Benefits");
            AddColumn("dbo.Benefits", "ID", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Benefits", "ID");
            DropColumn("dbo.Benefits", "BenefitID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Benefits", "BenefitID", c => c.Int(nullable: false, identity: true));
            DropPrimaryKey("dbo.Benefits");
            DropColumn("dbo.Benefits", "ID");
            AddPrimaryKey("dbo.Benefits", "BenefitID");
        }
    }
}
