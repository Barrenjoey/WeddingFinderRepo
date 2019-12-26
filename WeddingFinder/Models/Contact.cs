using System;
using System.Collections.Generic;

namespace WeddingFinder.Models
{
    public partial class Contact
    {
        public Contact()
        {
            Business = new HashSet<Business>();
        }

        public int ContactId { get; set; }
        public string ContactNumber { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }

        public virtual ICollection<Business> Business { get; set; }
    }
}
