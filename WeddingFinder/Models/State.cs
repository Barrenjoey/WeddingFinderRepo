using System;
using System.Collections.Generic;

namespace WeddingFinder.Models
{
    public partial class State
    {
        public State()
        {
            Address = new HashSet<Address>();
            Region = new HashSet<Region>();
        }

        public int StateId { get; set; }
        public string StateName { get; set; }
        public string StateDisplayName { get; set; }

        public virtual ICollection<Address> Address { get; set; }
        public virtual ICollection<Region> Region { get; set; }
    }
}
