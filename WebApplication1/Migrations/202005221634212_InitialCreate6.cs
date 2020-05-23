namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate6 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Loans", "ReturnedDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Loans", "ReturnedDate", c => c.DateTime(nullable: false));
        }
    }
}
