namespace CalumBSUAttempt2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddImageStringsToModels : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Actors", "ActorImage", c => c.String());
            AddColumn("dbo.Directors", "DirectorImage", c => c.String());
            AddColumn("dbo.Films", "FilmImage", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Films", "FilmImage");
            DropColumn("dbo.Directors", "DirectorImage");
            DropColumn("dbo.Actors", "ActorImage");
        }
    }
}
