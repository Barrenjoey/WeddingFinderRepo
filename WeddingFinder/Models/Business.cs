using System;
using System.Collections.Generic;

namespace WeddingFinder.Models
{
    public partial class Business
    {
        public Business()
        {
            Review = new HashSet<Review>();
            Subscription = new HashSet<Subscription>();
        }

        public int WedFinId { get; set; }
        public string BusinessName { get; set; }
        public int CategoryId { get; set; }
        public int AddressId { get; set; }
        public int ContactId { get; set; }
        public int ContentId { get; set; }
        public string ServiceRegions { get; set; }
        public decimal? ReviewRating { get; set; }
        public string Website { get; set; }
        public bool IsActive { get; set; }
        public DateTime? Created { get; set; }

        public virtual Address Address { get; set; }
        public virtual Category Category { get; set; }
        public virtual Contact Contact { get; set; }
        public virtual Content Content { get; set; }
        public virtual ICollection<Review> Review { get; set; }
        public virtual ICollection<Subscription> Subscription { get; set; }
    }
}
