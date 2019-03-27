using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CalumBSUAttempt2.Models
{
    public class News
    {
        public virtual int NewsId { get; set; }
        public virtual DateTime Date { get; set; }
        public virtual string Headline { get; set; }
        public virtual string BodyText { get; set; }
        public virtual string User { get; set; }

    }
}