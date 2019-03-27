using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CalumBSUAttempt2.Models
{
    public class BSUMovieWebsiteContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public BSUMovieWebsiteContext() : base("name=BSUMovieWebsiteContext")
        {
        }

        public System.Data.Entity.DbSet<CalumBSUAttempt2.Models.Film> Films { get; set; }

        public System.Data.Entity.DbSet<CalumBSUAttempt2.Models.Genre> Genres { get; set; }

        public System.Data.Entity.DbSet<CalumBSUAttempt2.Models.Actor> Actors { get; set; }

        public System.Data.Entity.DbSet<CalumBSUAttempt2.Models.Director> Directors { get; set; }

        public System.Data.Entity.DbSet<CalumBSUAttempt2.Models.Discussion> Discussions { get; set; }

        public System.Data.Entity.DbSet<CalumBSUAttempt2.Models.DiscussionInfo> DiscussionInfoes { get; set; }

        public System.Data.Entity.DbSet<CalumBSUAttempt2.Models.News> News { get; set; }
    }
}
