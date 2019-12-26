using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeddingFinder.Models;

namespace WeddingFinder.ViewModels
{
    public class SearchViewModel
    {
        public List<Category> CategoryList { get; set; }
        public List<Region> RegionList { get; set; }
        public List<State> StateList { get; set; }
        public string CurrentSearchFilter { get; set; }
    }
}
