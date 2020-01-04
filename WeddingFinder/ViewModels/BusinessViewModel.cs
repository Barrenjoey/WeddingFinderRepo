using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeddingFinder.Models;

namespace WeddingFinder.ViewModels
{
    public class BusinessViewModel
    {
        public Business Business { get; set; }
        public Region Region { get; set; }
        public Content Content { get; set; }
        public Address Address { get; set; }
        public Contact Contact { get; set; }

    }
}
