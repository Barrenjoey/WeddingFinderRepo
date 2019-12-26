using System;
using System.Collections.Generic;

namespace WeddingFinder.Models
{
    public partial class Region
    {
        public Region()
        {
            Address = new HashSet<Address>();
        }

        public int RegionId { get; set; }
        public string RegionName { get; set; }
        public int StateId { get; set; }

        public virtual State State { get; set; }
        public virtual ICollection<Address> Address { get; set; }
    }
}
