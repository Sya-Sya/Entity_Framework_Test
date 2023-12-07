namespace EFTest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AnimeDBV1 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.AniLists", name: "Name", newName: "nawa");
            AddColumn("dbo.AniLists", "AnimeRating_RateId", c => c.Int());
            AddColumn("dbo.AniLists", "MangaRating_RateId", c => c.Int());
            AlterColumn("dbo.AniLists", "nawa", c => c.String(nullable: false, maxLength: 50, unicode: false));
            AlterColumn("dbo.AniLists", "Description", c => c.String(maxLength: 200));
            AlterColumn("dbo.AniLists", "ReleasedDate", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.Ratings", "RatiingNumber", c => c.Single());
            CreateIndex("dbo.AniLists", "AnimeRating_RateId");
            CreateIndex("dbo.AniLists", "MangaRating_RateId");
            AddForeignKey("dbo.AniLists", "AnimeRating_RateId", "dbo.Ratings", "RateId");
            AddForeignKey("dbo.AniLists", "MangaRating_RateId", "dbo.Ratings", "RateId");
            DropColumn("dbo.AniLists", "Genre");
            CreateStoredProcedure(
                "dbo.InsertAnime",
                p => new
                    {
                        Name = p.String(maxLength: 50, unicode: false),
                        Description = p.String(maxLength: 200),
                        ReleasedDate = p.DateTime(storeType: "datetime2"),
                        Rating_RateId = p.Int(),
                        AnimeRating_RateId = p.Int(),
                        MangaRating_RateId = p.Int(),
                    },
                body:
                    @"INSERT [dbo].[AniLists]([nawa], [Description], [ReleasedDate], [Rating_RateId], [AnimeRating_RateId], [MangaRating_RateId])
                      VALUES (@Name, @Description, @ReleasedDate, @Rating_RateId, @AnimeRating_RateId, @MangaRating_RateId)
                      
                      DECLARE @Id int
                      SELECT @Id = [Id]
                      FROM [dbo].[AniLists]
                      WHERE @@ROWCOUNT > 0 AND [Id] = scope_identity()
                      
                      SELECT t0.[Id] AS id
                      FROM [dbo].[AniLists] AS t0
                      WHERE @@ROWCOUNT > 0 AND t0.[Id] = @Id"
            );
            
            CreateStoredProcedure(
                "dbo.AniList_Update",
                p => new
                    {
                        Id = p.Int(),
                        nawa = p.String(maxLength: 50, unicode: false),
                        Description = p.String(maxLength: 200),
                        ReleasedDate = p.DateTime(storeType: "datetime2"),
                        Rating_RateId = p.Int(),
                        AnimeRating_RateId = p.Int(),
                        MangaRating_RateId = p.Int(),
                    },
                body:
                    @"UPDATE [dbo].[AniLists]
                      SET [nawa] = @nawa, [Description] = @Description, [ReleasedDate] = @ReleasedDate, [Rating_RateId] = @Rating_RateId, [AnimeRating_RateId] = @AnimeRating_RateId, [MangaRating_RateId] = @MangaRating_RateId
                      WHERE ([Id] = @Id)"
            );
            
            CreateStoredProcedure(
                "dbo.DeleteAnime",
                p => new
                    {
                        id = p.Int(),
                        Rating_RateId = p.Int(),
                        AnimeRating_RateId = p.Int(),
                        MangaRating_RateId = p.Int(),
                    },
                body:
                    @"DELETE [dbo].[AniLists]
                      WHERE (((([Id] = @id) AND (([Rating_RateId] = @Rating_RateId) OR ([Rating_RateId] IS NULL AND @Rating_RateId IS NULL))) AND (([AnimeRating_RateId] = @AnimeRating_RateId) OR ([AnimeRating_RateId] IS NULL AND @AnimeRating_RateId IS NULL))) AND (([MangaRating_RateId] = @MangaRating_RateId) OR ([MangaRating_RateId] IS NULL AND @MangaRating_RateId IS NULL)))"
            );
            
        }
        
        public override void Down()
        {
            DropStoredProcedure("dbo.DeleteAnime");
            DropStoredProcedure("dbo.AniList_Update");
            DropStoredProcedure("dbo.InsertAnime");
            AddColumn("dbo.AniLists", "Genre", c => c.String());
            DropForeignKey("dbo.AniLists", "MangaRating_RateId", "dbo.Ratings");
            DropForeignKey("dbo.AniLists", "AnimeRating_RateId", "dbo.Ratings");
            DropIndex("dbo.AniLists", new[] { "MangaRating_RateId" });
            DropIndex("dbo.AniLists", new[] { "AnimeRating_RateId" });
            AlterColumn("dbo.Ratings", "RatiingNumber", c => c.Single(nullable: false));
            AlterColumn("dbo.AniLists", "ReleasedDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.AniLists", "Description", c => c.String());
            AlterColumn("dbo.AniLists", "nawa", c => c.String());
            DropColumn("dbo.AniLists", "MangaRating_RateId");
            DropColumn("dbo.AniLists", "AnimeRating_RateId");
            RenameColumn(table: "dbo.AniLists", name: "nawa", newName: "Name");
        }
    }
}
