using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CalumBSUAttempt2.Models
{
    public class Actor
    {
        public virtual int ActorId { get; set; }
        public virtual string ActorImage { get; set; }
        public virtual string ActorName { get; set; }
        public virtual string ActorBio { get; set; }
        public virtual DateTime ActorDOB { get; set; }
        public virtual decimal Rating { get; set; }
        public virtual string User { get; set; }
    }
}