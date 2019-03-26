using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CalumBSUAttempt2.Models
{
    public class DirectorComment
    {
        public virtual int DirectorCommentId { get; set; }
        public virtual int DirectorId { get; set; }
        public virtual string Comment { get; set; }
        public virtual Director Director { get; set; }
        public virtual string User { get; set; }
    }
}