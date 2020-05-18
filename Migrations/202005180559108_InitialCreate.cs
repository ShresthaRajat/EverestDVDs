namespace Everest_DVD_Store.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Actors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 100),
                        LastName = c.String(maxLength: 100),
                        Email = c.String(),
                        BirthDate = c.DateTime(nullable: false),
                        Gender = c.String(),
                        PhoneNumber = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CastMembers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ActorId = c.Int(nullable: false),
                        DVDTitle = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Actors", t => t.ActorId, cascadeDelete: true)
                .ForeignKey("dbo.DVDs", t => t.DVDTitle, cascadeDelete: true)
                .Index(t => t.ActorId)
                .Index(t => t.DVDTitle);
            
            CreateTable(
                "dbo.DVDs",
                c => new
                    {
                        DVDTitle = c.String(nullable: false, maxLength: 128),
                        DVDStudio = c.String(nullable: false, maxLength: 100),
                        DVDProducer = c.String(),
                        RunTime = c.String(),
                        DVDsCategory = c.String(maxLength: 128),
                        ReleaseDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.DVDTitle)
                .ForeignKey("dbo.DVDs", t => t.DVDsCategory)
                .Index(t => t.DVDsCategory);
            
            CreateTable(
                "dbo.Copies",
                c => new
                    {
                        CopyNumber = c.Int(nullable: false, identity: true),
                        DVDTilte = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.CopyNumber)
                .ForeignKey("dbo.DVDs", t => t.DVDTilte, cascadeDelete: true)
                .Index(t => t.DVDTilte);
            
            CreateTable(
                "dbo.DVDCategories",
                c => new
                    {
                        DVDsCategory = c.String(nullable: false, maxLength: 100),
                        AgeRestricted = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.DVDsCategory);
            
            CreateTable(
                "dbo.Loans",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MemberId = c.Int(nullable: false),
                        CopyId = c.Int(nullable: false),
                        IssueDate = c.DateTime(nullable: false),
                        ReturnDate = c.DateTime(nullable: false),
                        LoanType = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Copies", t => t.CopyId, cascadeDelete: true)
                .ForeignKey("dbo.LoanTypes", t => t.LoanType, cascadeDelete: true)
                .ForeignKey("dbo.Members", t => t.MemberId, cascadeDelete: true)
                .Index(t => t.MemberId)
                .Index(t => t.CopyId)
                .Index(t => t.LoanType);
            
            CreateTable(
                "dbo.LoanTypes",
                c => new
                    {
                        Loan_Type = c.String(nullable: false, maxLength: 100),
                        LoanRate = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Loan_Type);
            
            CreateTable(
                "dbo.Members",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        Phone = c.String(nullable: false),
                        Email = c.String(),
                        Age = c.Int(nullable: false),
                        MemberCategoryId = c.String(maxLength: 200),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.MembershipCategories", t => t.MemberCategoryId)
                .Index(t => t.MemberCategoryId);
            
            CreateTable(
                "dbo.MembershipCategories",
                c => new
                    {
                        MembershipCategory = c.String(nullable: false, maxLength: 200),
                        TotalLoan = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.MembershipCategory);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Loans", "MemberId", "dbo.Members");
            DropForeignKey("dbo.Members", "MemberCategoryId", "dbo.MembershipCategories");
            DropForeignKey("dbo.Loans", "LoanType", "dbo.LoanTypes");
            DropForeignKey("dbo.Loans", "CopyId", "dbo.Copies");
            DropForeignKey("dbo.Copies", "DVDTilte", "dbo.DVDs");
            DropForeignKey("dbo.CastMembers", "DVDTitle", "dbo.DVDs");
            DropForeignKey("dbo.DVDs", "DVDsCategory", "dbo.DVDs");
            DropForeignKey("dbo.CastMembers", "ActorId", "dbo.Actors");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Members", new[] { "MemberCategoryId" });
            DropIndex("dbo.Loans", new[] { "LoanType" });
            DropIndex("dbo.Loans", new[] { "CopyId" });
            DropIndex("dbo.Loans", new[] { "MemberId" });
            DropIndex("dbo.Copies", new[] { "DVDTilte" });
            DropIndex("dbo.DVDs", new[] { "DVDsCategory" });
            DropIndex("dbo.CastMembers", new[] { "DVDTitle" });
            DropIndex("dbo.CastMembers", new[] { "ActorId" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.MembershipCategories");
            DropTable("dbo.Members");
            DropTable("dbo.LoanTypes");
            DropTable("dbo.Loans");
            DropTable("dbo.DVDCategories");
            DropTable("dbo.Copies");
            DropTable("dbo.DVDs");
            DropTable("dbo.CastMembers");
            DropTable("dbo.Actors");
        }
    }
}
