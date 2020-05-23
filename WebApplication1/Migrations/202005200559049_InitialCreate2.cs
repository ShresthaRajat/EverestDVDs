namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.DVDProducerActors", "ActorId", "dbo.Actors");
            DropForeignKey("dbo.DVDProducerActors", "DVDId", "dbo.DVDDetails");
            DropForeignKey("dbo.DVDProducerActors", "ProducerId", "dbo.Producers");
            DropIndex("dbo.DVDProducerActors", new[] { "DVDId" });
            DropIndex("dbo.DVDProducerActors", new[] { "ActorId" });
            DropIndex("dbo.DVDProducerActors", new[] { "ProducerId" });
            AddColumn("dbo.DVDProducerActors", "castMember_Id", c => c.Int());
            AddColumn("dbo.DVDProducerActors", "dVDProducer_Id", c => c.Int());
            CreateIndex("dbo.DVDProducerActors", "castMember_Id");
            CreateIndex("dbo.DVDProducerActors", "dVDProducer_Id");
            AddForeignKey("dbo.DVDProducerActors", "castMember_Id", "dbo.CastMembers", "Id");
            AddForeignKey("dbo.DVDProducerActors", "dVDProducer_Id", "dbo.DVDProducers", "Id");
            DropColumn("dbo.DVDProducerActors", "DVDId");
            DropColumn("dbo.DVDProducerActors", "ActorId");
            DropColumn("dbo.DVDProducerActors", "ProducerId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.DVDProducerActors", "ProducerId", c => c.Int(nullable: false));
            AddColumn("dbo.DVDProducerActors", "ActorId", c => c.Int(nullable: false));
            AddColumn("dbo.DVDProducerActors", "DVDId", c => c.Int(nullable: false));
            DropForeignKey("dbo.DVDProducerActors", "dVDProducer_Id", "dbo.DVDProducers");
            DropForeignKey("dbo.DVDProducerActors", "castMember_Id", "dbo.CastMembers");
            DropIndex("dbo.DVDProducerActors", new[] { "dVDProducer_Id" });
            DropIndex("dbo.DVDProducerActors", new[] { "castMember_Id" });
            DropColumn("dbo.DVDProducerActors", "dVDProducer_Id");
            DropColumn("dbo.DVDProducerActors", "castMember_Id");
            CreateIndex("dbo.DVDProducerActors", "ProducerId");
            CreateIndex("dbo.DVDProducerActors", "ActorId");
            CreateIndex("dbo.DVDProducerActors", "DVDId");
            AddForeignKey("dbo.DVDProducerActors", "ProducerId", "dbo.Producers", "ProducerId", cascadeDelete: true);
            AddForeignKey("dbo.DVDProducerActors", "DVDId", "dbo.DVDDetails", "DVDId", cascadeDelete: true);
            AddForeignKey("dbo.DVDProducerActors", "ActorId", "dbo.Actors", "ActorId", cascadeDelete: true);
        }
    }
}
