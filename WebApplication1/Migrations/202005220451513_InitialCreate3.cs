namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate3 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.DVDDetails", "NoOfCopy", c => c.String());
            AlterColumn("dbo.DVDDetails", "AgeRestriction", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.DVDDetails", "AgeRestriction", c => c.Boolean(nullable: false));
            AlterColumn("dbo.DVDDetails", "NoOfCopy", c => c.Int(nullable: false));
        }
    }
}
