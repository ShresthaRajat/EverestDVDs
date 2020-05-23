namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCrete : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.DVDDetails", "DateAdded", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.DVDDetails", "DateAdded", c => c.String());
        }
    }
}
