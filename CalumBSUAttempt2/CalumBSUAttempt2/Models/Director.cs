using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CalumBSUAttempt2.Models
{
    public class Director
    {
        public virtual int DirectorId { get; set; }
        public virtual string DirectorImage { get; set; }
        public virtual string DirectorName { get; set; }
        public virtual string DirectorBio { get; set; }
        public virtual DateTime DirectorDOB { get; set; }
        public virtual decimal Rating { get; set; }
    }
}