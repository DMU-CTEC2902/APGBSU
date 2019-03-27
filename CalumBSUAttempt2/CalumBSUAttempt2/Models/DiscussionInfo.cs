using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CalumBSUAttempt2.Models
{
    public class DiscussionInfo
    {
        public virtual int DiscussionInfoId { get; set; }
        public virtual string Message { get; set; }
        public virtual int DiscussionId { get; set; }
        public virtual Discussion Discussion { get; set; }
        public virtual string User { get; set; }
    }
}