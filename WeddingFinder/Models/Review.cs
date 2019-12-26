using System;
using System.Collections.Generic;

namespace WeddingFinder.Models
{
    public partial class Review
    {
        public int ReviewId { get; set; }
        public int WedFinId { get; set; }
        public string Content { get; set; }
        public int Rating { get; set; }
        public string ReviewerName { get; set; }
        public DateTime? ReviewDate { get; set; }

        public virtual Business WedFin { get; set; }
    }
}
