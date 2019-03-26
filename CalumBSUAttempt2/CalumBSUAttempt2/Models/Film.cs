using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CalumBSUAttempt2.Models
{
    public class Film
    {
        public virtual int FilmId { get; set; }
        public virtual string FilmImage { get; set; }
        public virtual string FilmName { get; set; }
        public virtual string FilmDescription { get; set; }
        public virtual decimal Rating { get; set; }
        public virtual DateTime ReleaseDate { get; set; }
        public virtual int FilmLength { get; set; }
        public virtual int GenreId { get; set; }
        public virtual Genre Genre { get; set; }
        public virtual string User { get; set; }
    }
}