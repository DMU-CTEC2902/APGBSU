using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CalumBSUAttempt2.Models
{
    public class Discussion
    {
        public virtual int DiscussionId { get; set; }
        public virtual string Name { get; set; }
        public virtual string User { get; set; }
    }
}