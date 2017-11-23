namespace _3esiEmployeeSystemV1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeansInput5 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Currencies", "Abbreviation", c => c.String(maxLength: 10));
            AlterColumn("dbo.HeritageCompanies", "Name", c => c.String(maxLength: 32));
            AlterColumn("dbo.HeritageCompanies", "Abbreviation", c => c.String(maxLength: 10));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.HeritageCompanies", "Abbreviation", c => c.String());
            AlterColumn("dbo.HeritageCompanies", "Name", c => c.String(maxLength: 50));
            DropColumn("dbo.Currencies", "Abbreviation");
        }
    }
}
