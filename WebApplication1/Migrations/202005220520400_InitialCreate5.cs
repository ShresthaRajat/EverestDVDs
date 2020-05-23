namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate5 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Actors", "ImagePath", c => c.String());
            AddColumn("dbo.CastMembers", "ImagePath", c => c.String());
            DropColumn("dbo.Actors", "Photo");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Actors", "Photo", c => c.String());
            DropColumn("dbo.CastMembers", "ImagePath");
            DropColumn("dbo.Actors", "ImagePath");
        }
    }
}
