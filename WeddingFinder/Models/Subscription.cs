using System;
using System.Collections.Generic;

namespace WeddingFinder.Models
{
    public partial class Subscription
    {
        public int SubscriptionId { get; set; }
        public int WedFinId { get; set; }
        public int SubTypeId { get; set; }
        public DateTime SubStart { get; set; }
        public DateTime? SubExpire { get; set; }
        public DateTime? LastBilling { get; set; }
        public bool IsFinancial { get; set; }

        public virtual SubscriptionType SubType { get; set; }
        public virtual Business WedFin { get; set; }
    }
}
