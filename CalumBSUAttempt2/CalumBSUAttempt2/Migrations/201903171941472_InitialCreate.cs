namespace CalumBSUAttempt2.Migrations
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
                        ActorName = c.String(),
                        ActorBio = c.String(),
                        ActorDOB = c.DateTime(nullable: false),
                        Rating = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.ActorId);
            
            CreateTable(
                "dbo.Directors",
                c => new
                    {
                        DirectorId = c.Int(nullable: false, identity: true),
                        DirectorName = c.String(),
                        DirectorBio = c.String(),
                        DirectorDOB = c.DateTime(nullable: false),
                        Rating = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.DirectorId);
            
            CreateTable(
                "dbo.Films",
                c => new
                    {
                        FilmId = c.Int(nullable: false, identity: true),
                        FilmName = c.String(),
                        FilmDescription = c.String(),
                        Rating = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ReleaseDate = c.DateTime(nullable: false),
                        FilmLength = c.Int(nullable: false),
                        GenreId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.FilmId)
                .ForeignKey("dbo.Genres", t => t.GenreId, cascadeDelete: true)
                .Index(t => t.GenreId);
            
            CreateTable(
                "dbo.Genres",
                c => new
                    {
                        GenreId = c.Int(nullable: false, identity: true),
                        GenreName = c.String(),
                    })
                .PrimaryKey(t => t.GenreId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Films", "GenreId", "dbo.Genres");
            DropIndex("dbo.Films", new[] { "GenreId" });
            DropTable("dbo.Genres");
            DropTable("dbo.Films");
            DropTable("dbo.Directors");
            DropTable("dbo.Actors");
        }
    }
}
