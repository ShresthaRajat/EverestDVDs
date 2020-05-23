namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate4 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DVDDetails", "DVDCoverPath", c => c.String());
            DropColumn("dbo.DVDDetails", "DVDCover");
        }
        
        public override void Down()
        {
            AddColumn("dbo.DVDDetails", "DVDCover", c => c.String());
            DropColumn("dbo.DVDDetails", "DVDCoverPath");
        }
    }
}
