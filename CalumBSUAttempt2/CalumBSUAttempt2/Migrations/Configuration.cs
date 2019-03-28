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
            /*
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
            */

            context.Actors.AddOrUpdate(actor => actor.ActorId,
                new Actor() { ActorId = 1, ActorImage = "https://m.media-amazon.com/images/M/MV5BMjExOTY3NzExM15BMl5BanBnXkFtZTgwOTg1OTAzMTE@._V1_UX214_CR0,0,214,317_AL_.jpg", ActorName = "Michael B Jordan", ActorBio = "Antagonist in Black Panther", ActorDOB = new DateTime(09 / 03 / 1987), Rating = 8m, User = "rhyscruz" },
                new Actor() { ActorId = 2, ActorImage = "https://m.media-amazon.com/images/M/MV5BMjA1MTQ3NzU1MV5BMl5BanBnXkFtZTgwMDE3Mjg0MzE@._V1_UY317_CR52,0,214,317_AL_.jpg", ActorName = "Liam Neeson", ActorBio = "Kosh wielding pub merchant", ActorDOB = new DateTime(07 / 06 / 1952), Rating = 7m, User = "calum ewart" }
                );

            context.Films.AddOrUpdate(films => films.FilmId,
              new Film() { FilmId = 1, FilmImage = "https://upload.wikimedia.org/wikipedia/en/0/0c/Black_Panther_film_poster.jpg", FilmName = "Black Panther", FilmDescription = "Marvel superhero movie based on the black panther comics", ReleaseDate = new DateTime(09 / 03 / 2018), Rating = 8m, User = "rhyscruz", FilmLength = 187, GenreId = 1 }

                );

            context.Directors.AddOrUpdate(director => director.DirectorId,
              new Director() { DirectorId = 1, DirectorImage = "https://upload.wikimedia.org/wikipedia/en/0/0c/Black_Panther_film_poster.jpg", DirectorName = "Black Panther", DirectorBio = "Marvel superhero movie based on the black panther comics", DirectorDOB = new DateTime(09 / 03 / 1978), Rating = 8m, User = "rhyscruz" }

                );

            context.Genres.AddOrUpdate(genre => genre.GenreId,
              new Genre() { GenreId = 1, GenreName = "Comedy", User = "calum ewart" }

              );

            context.News.AddOrUpdate(news => news.NewsId,
              new News() { NewsId = 1, Date = new DateTime(27/03/2019), Headline = "End Game Spoilers!", BodyText = "Ant Man Defeates Thanos by shrinkings and *****", User = "calum ewart"}

              );
        }
    }
}
