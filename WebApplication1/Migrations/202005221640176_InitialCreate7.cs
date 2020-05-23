namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate7 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Function12Model",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        dVDDetail_DVDId = c.Int(),
                        loan_LoanId = c.Int(),
                        member_MemberId = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.DVDDetails", t => t.dVDDetail_DVDId)
                .ForeignKey("dbo.Loans", t => t.loan_LoanId)
                .ForeignKey("dbo.Members", t => t.member_MemberId)
                .Index(t => t.dVDDetail_DVDId)
                .Index(t => t.loan_LoanId)
                .Index(t => t.member_MemberId);
            
            CreateTable(
                "dbo.LoanViewModels",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        MemberId = c.Int(nullable: false),
                        Name = c.String(),
                        CName = c.String(),
                        NumberOfLoans = c.Int(nullable: false),
                        LoanStatus = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Function12Model", "member_MemberId", "dbo.Members");
            DropForeignKey("dbo.Function12Model", "loan_LoanId", "dbo.Loans");
            DropForeignKey("dbo.Function12Model", "dVDDetail_DVDId", "dbo.DVDDetails");
            DropIndex("dbo.Function12Model", new[] { "member_MemberId" });
            DropIndex("dbo.Function12Model", new[] { "loan_LoanId" });
            DropIndex("dbo.Function12Model", new[] { "dVDDetail_DVDId" });
            DropTable("dbo.LoanViewModels");
            DropTable("dbo.Function12Model");
        }
    }
}
