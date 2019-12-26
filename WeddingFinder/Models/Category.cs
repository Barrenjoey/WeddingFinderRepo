using System;
using System.Collections.Generic;

namespace WeddingFinder.Models
{
    public partial class Category
    {
        public Category()
        {
            Business = new HashSet<Business>();
        }

        public int CategoryId { get; set; }
        public string CategoryName { get; set; }

        public virtual ICollection<Business> Business { get; set; }
    }
}
