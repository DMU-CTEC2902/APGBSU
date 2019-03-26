using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CalumBSUAttempt2.Models
{
    public class ActorComment
    {
        public virtual int ActorCommentId { get; set; }
        public virtual int ActorId { get; set; }
        public virtual string Comment { get; set; }
        public virtual Actor Actor { get; set; }
        public virtual string User { get; set; }
    }
}