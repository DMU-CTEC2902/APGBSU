namespace CalumBSUAttempt2.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using CalumBSUAttempt2.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<CalumBSUAttempt2.Models.BSUMovieWebsiteContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "CalumBSUAttempt2.Models.BSUMovieWebsiteContext";
        }

        protected override void Seed(CalumBSUAttempt2.Models.BSUMovieWebsiteContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            
            Genre genre1 = new Genre();
            genre1.GenreId = 1;
            genre1.GenreName = "Comedy";
            
            Genre genre2 = new Genre();
            genre2.GenreId = 2;
            genre2.GenreName = "Rom-Com";

            Genre genre3 = new Genre();
            genre3.GenreId = 3;
            genre3.GenreName = "Horror";

            base.Seed(context);
    }
    }
}
