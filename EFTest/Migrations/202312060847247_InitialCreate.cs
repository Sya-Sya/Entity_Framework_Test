namespace EFTest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AniLists",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        Genre = c.String(),
                        ReleasedDate = c.DateTime(nullable: false),
                        Rating_RateId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Ratings", t => t.Rating_RateId)
                .Index(t => t.Rating_RateId);
            
            CreateTable(
                "dbo.Ratings",
                c => new
                    {
                        RateId = c.Int(nullable: false, identity: true),
                        RatiingNumber = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.RateId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AniLists", "Rating_RateId", "dbo.Ratings");
            DropIndex("dbo.AniLists", new[] { "Rating_RateId" });
            DropTable("dbo.Ratings");
            DropTable("dbo.AniLists");
        }
    }
}
