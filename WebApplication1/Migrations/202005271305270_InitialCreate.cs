namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Function12Model", "member_MemberId", "dbo.Members");
            DropForeignKey("dbo.Function12Model", "loan_LoanId", "dbo.Loans");
            DropForeignKey("dbo.Loans", "MemberId", "dbo.Members");
            DropForeignKey("dbo.Members", "CategoryId", "dbo.MemberCategories");
            DropForeignKey("dbo.Loans", "DVDId", "dbo.DVDDetails");
            DropForeignKey("dbo.Function12Model", "dVDDetail_DVDId", "dbo.DVDDetails");
            DropForeignKey("dbo.DVDProducerActors", "dVDProducer_Id", "dbo.DVDProducers");
            DropForeignKey("dbo.DVDProducers", "ProducerId", "dbo.Producers");
            DropForeignKey("dbo.DVDProducers", "DVDId", "dbo.DVDDetails");
            DropForeignKey("dbo.DVDProducerActors", "castMember_Id", "dbo.CastMembers");
            DropForeignKey("dbo.CastMembers", "DVDId", "dbo.DVDDetails");
            DropForeignKey("dbo.CastMembers", "ActorId", "dbo.Actors");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Members", new[] { "CategoryId" });
            DropIndex("dbo.Loans", new[] { "MemberId" });
            DropIndex("dbo.Loans", new[] { "DVDId" });
            DropIndex("dbo.Function12Model", new[] { "member_MemberId" });
            DropIndex("dbo.Function12Model", new[] { "loan_LoanId" });
            DropIndex("dbo.Function12Model", new[] { "dVDDetail_DVDId" });
            DropIndex("dbo.DVDProducers", new[] { "DVDId" });
            DropIndex("dbo.DVDProducers", new[] { "ProducerId" });
            DropIndex("dbo.DVDProducerActors", new[] { "dVDProducer_Id" });
            DropIndex("dbo.DVDProducerActors", new[] { "castMember_Id" });
            DropIndex("dbo.CastMembers", new[] { "ActorId" });
            DropIndex("dbo.CastMembers", new[] { "DVDId" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.LoanViewModels");
            DropTable("dbo.MemberCategories");
            DropTable("dbo.Members");
            DropTable("dbo.Loans");
            DropTable("dbo.Function12Model");
            DropTable("dbo.Producers");
            DropTable("dbo.DVDProducers");
            DropTable("dbo.DVDProducerActors");
            DropTable("dbo.DVDDetails");
            DropTable("dbo.CastMembers");
            DropTable("dbo.Actors");
        }
    }
}
