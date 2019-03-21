using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CalumBSUAttempt2.Models
{
    public class FilmComment
    {
        public virtual int FilmCommentId { get; set; }
        public virtual int FilmId { get; set; }
        public virtual string Comment { get; set; }
        public virtual Film Film { get; set; }
    }
}