using System;
using System.Collections.Generic;

namespace WeddingFinder.Models
{
    public partial class Address
    {
        public Address()
        {
            Business = new HashSet<Business>();
        }

        public int AddressId { get; set; }
        public string Country { get; set; }
        public int StateId { get; set; }
        public int RegionId { get; set; }
        public string Suburb { get; set; }
        public string Street { get; set; }
        public string SteetNumber { get; set; }
        public string Postcode { get; set; }

        public virtual Region Region { get; set; }
        public virtual State State { get; set; }
        public virtual ICollection<Business> Business { get; set; }
    }
}
