namespace WebApplication1.Migrations
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
                        ActorId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Photo = c.String(),
                        DOB = c.DateTime(nullable: false),
                        Gender = c.String(),
                        Nationality = c.String(),
                    })
                .PrimaryKey(t => t.ActorId);
            
            CreateTable(
                "dbo.CastMembers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DVDId = c.Int(nullable: false),
                        ActorId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Actors", t => t.ActorId, cascadeDelete: true)
                .ForeignKey("dbo.DVDDetails", t => t.DVDId, cascadeDelete: true)
                .Index(t => t.DVDId)
                .Index(t => t.ActorId);
            
            CreateTable(
                "dbo.DVDDetails",
                c => new
                    {
                        DVDId = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Genre = c.String(),
                        NoOfCopy = c.Int(nullable: false),
                        AgeRestriction = c.Boolean(nullable: false),
                        StudioName = c.String(),
                        DVDCover = c.String(),
                        DateAdded = c.String(),
                    })
                .PrimaryKey(t => t.DVDId);
            
            CreateTable(
                "dbo.DVDProducers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProducerId = c.Int(nullable: false),
                        DVDId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DVDDetails", t => t.DVDId, cascadeDelete: true)
                .ForeignKey("dbo.Producers", t => t.ProducerId, cascadeDelete: true)
                .Index(t => t.ProducerId)
                .Index(t => t.DVDId);
            
            CreateTable(
                "dbo.Producers",
                c => new
                    {
                        ProducerId = c.Int(nullable: false, identity: true),
                        ProducerName = c.String(),
                        DOB = c.DateTime(nullable: false),
                        Gender = c.String(),
                    })
                .PrimaryKey(t => t.ProducerId);
            
            CreateTable(
                "dbo.Loans",
                c => new
                    {
                        LoanId = c.Int(nullable: false, identity: true),
                        IssuedDate = c.DateTime(nullable: false),
                        ReturnedDate = c.DateTime(nullable: false),
                        TotalFine = c.Int(nullable: false),
                        DVDId = c.Int(nullable: false),
                        MemberId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.LoanId)
                .ForeignKey("dbo.DVDDetails", t => t.DVDId, cascadeDelete: true)
                .ForeignKey("dbo.Members", t => t.MemberId, cascadeDelete: true)
                .Index(t => t.DVDId)
                .Index(t => t.MemberId);
            
            CreateTable(
                "dbo.Members",
                c => new
                    {
                        MemberId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        DOB = c.DateTime(nullable: false),
                        Gender = c.String(),
                        Address = c.String(),
                        Phone = c.String(),
                        Email = c.String(),
                        CategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MemberId)
                .ForeignKey("dbo.MemberCategories", t => t.CategoryId, cascadeDelete: true)
                .Index(t => t.CategoryId);
            
            CreateTable(
                "dbo.MemberCategories",
                c => new
                    {
                        CategoryId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        TotalLoan = c.Int(nullable: false),
                        TotalKeepDays = c.Int(nullable: false),
                        Fine = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CategoryId);
            
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
            DropForeignKey("dbo.Members", "CategoryId", "dbo.MemberCategories");
            DropForeignKey("dbo.Loans", "DVDId", "dbo.DVDDetails");
            DropForeignKey("dbo.DVDProducers", "ProducerId", "dbo.Producers");
            DropForeignKey("dbo.DVDProducers", "DVDId", "dbo.DVDDetails");
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
            DropIndex("dbo.DVDProducers", new[] { "DVDId" });
            DropIndex("dbo.DVDProducers", new[] { "ProducerId" });
            DropIndex("dbo.CastMembers", new[] { "ActorId" });
            DropIndex("dbo.CastMembers", new[] { "DVDId" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.MemberCategories");
            DropTable("dbo.Members");
            DropTable("dbo.Loans");
            DropTable("dbo.Producers");
            DropTable("dbo.DVDProducers");
            DropTable("dbo.DVDDetails");
            DropTable("dbo.CastMembers");
            DropTable("dbo.Actors");
        }
    }
}
