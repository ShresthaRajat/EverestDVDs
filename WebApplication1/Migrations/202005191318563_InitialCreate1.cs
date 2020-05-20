namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DVDProducerActors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DVDId = c.Int(nullable: false),
                        ActorId = c.Int(nullable: false),
                        ProducerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Actors", t => t.ActorId, cascadeDelete: true)
                .ForeignKey("dbo.DVDDetails", t => t.DVDId, cascadeDelete: true)
                .ForeignKey("dbo.Producers", t => t.ProducerId, cascadeDelete: true)
                .Index(t => t.DVDId)
                .Index(t => t.ActorId)
                .Index(t => t.ProducerId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DVDProducerActors", "ProducerId", "dbo.Producers");
            DropForeignKey("dbo.DVDProducerActors", "DVDId", "dbo.DVDDetails");
            DropForeignKey("dbo.DVDProducerActors", "ActorId", "dbo.Actors");
            DropIndex("dbo.DVDProducerActors", new[] { "ProducerId" });
            DropIndex("dbo.DVDProducerActors", new[] { "ActorId" });
            DropIndex("dbo.DVDProducerActors", new[] { "DVDId" });
            DropTable("dbo.DVDProducerActors");
        }
    }
}
