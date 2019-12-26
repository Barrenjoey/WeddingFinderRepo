using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeddingFinder.ViewModels;

namespace WeddingFinder.Models
{
    public class CategoriesViewModel
    {
        public string Category { get; set; }
        public string State { get; set; }
        public string Region { get; set; }
        public List<BusinessViewModel> BusinessList { get; set; }        
    }
}
