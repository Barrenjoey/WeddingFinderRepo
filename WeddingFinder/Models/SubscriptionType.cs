using System;
using System.Collections.Generic;

namespace WeddingFinder.Models
{
    public partial class SubscriptionType
    {
        public SubscriptionType()
        {
            Subscription = new HashSet<Subscription>();
        }

        public int SubTypeId { get; set; }
        public string SubscriptionName { get; set; }
        public decimal? MonthlyCost { get; set; }

        public virtual ICollection<Subscription> Subscription { get; set; }
    }
}
