using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WeddingFinder.Context;
using WeddingFinder.Models;
using WeddingFinder.ViewModels;
using WeddingFinder.Helpers.Enums;

namespace WeddingFinder.Controllers
{
    public abstract class BaseController : Controller
    {
        public WeddingFinderContext Context { get; set; }
        public SearchViewModel SearchData { get; set; }
        public BaseController()
        {
            Context = new WeddingFinderContext();
            SearchData = GetSearchData();                        
        }

        private SearchViewModel GetSearchData()
        {
            SearchViewModel searchData = new SearchViewModel();
            searchData.CategoryList = Context.Category.ToList();
            searchData.StateList = Context.State.ToList();
            searchData.StateList.Insert(0, new State { StateName = "All States", StateDisplayName = "All States"});
            //searchData.RegionList = Context.Region.ToList();            
            return searchData;
        }                

        /*public List<BusinessViewModel> GetAllBusinessByCategory(string category)
        {
            List<BusinessViewModel> businessViewModelList = new List<BusinessViewModel>();            
            List<Business> businesses = Context.Business.Where(x => x.Category.ToString() == category).ToList();
            foreach (var business in businesses)
            {
                businessViewModelList.Add(new BusinessViewModel { Business = business});
            }
            return businessViewModelList;
        }*/

        public Business GetBusinessByName(string businessName)
        {
            Business business = new Business();
            if (!string.IsNullOrEmpty(businessName))
            {
                business = Context.Business.Where(x => x.BusinessName == businessName).FirstOrDefault();
            }
            return business;
        }

        public Content GetContentbyID(int? contentID)
        {
            Content content = new Content();
            if (contentID != null)
            {
                content = Context.Content.Where(x => x.ContentId == contentID).FirstOrDefault();
            }
            return content;
        }

        public BusinessViewModel GetBusinessViewModel(Business business)
        {
            BusinessViewModel viewmodel = new BusinessViewModel();
            viewmodel = (from bus in Context.Business
                            join adr in Context.Address on bus.AddressId equals adr.AddressId
                            join sta in Context.State on adr.StateId equals sta.StateId
                            where bus.WedFinId == business.WedFinId
                            select new BusinessViewModel { Business = bus, Address = adr, Content = bus.Content, Region = adr.Region, Contact = bus.Contact }).FirstOrDefault();
            return viewmodel;
        }

        public CategoriesViewModel GetCategoriesViewModel(string category)
        {            
            CategoriesViewModel viewModel = new CategoriesViewModel();
            List<BusinessViewModel> businessViewModelList = new List<BusinessViewModel>();
            List<Business> businesses = Context.Business.Where(x => x.Category.ToString() == category).ToList();
            foreach (var business in businesses)
            {
                businessViewModelList.Add(new BusinessViewModel { Business = business });
            }
            viewModel.BusinessList = businessViewModelList;
            viewModel.Category = category;
            return viewModel;
        }

        public CategoriesViewModel GetCategoriesViewModelWithSearch(string category, string state, string region)
        {
            CategoriesViewModel viewModel = new CategoriesViewModel();
            IEnumerable<BusinessViewModel> businessViewModelList = new List<BusinessViewModel>();            
            Category selectedCategory = Context.Category.Where(x => x.CategoryName == category).FirstOrDefault();
            State selectedState;
            SearchData.CurrentSearchFilter = selectedCategory.CategoryName;
            // All States by Category
            if (state == "All States")
            {
                businessViewModelList = from bus in Context.Business
                                        join adr in Context.Address on bus.AddressId equals adr.AddressId
                                        join sta in Context.State on adr.StateId equals sta.StateId
                                        where bus.CategoryId == selectedCategory.CategoryId
                                        select new BusinessViewModel { Business = bus, Address = adr, Content = bus.Content, Region = adr.Region };                
            }
            // One State All Regions by Category
            else if (state != "All States" && region == "All Regions")
            {                
                selectedState = Context.State.Where(x => x.StateDisplayName == state).FirstOrDefault();
                businessViewModelList = from bus in Context.Business
                                             join adr in Context.Address on bus.AddressId equals adr.AddressId
                                             join sta in Context.State on adr.StateId equals sta.StateId
                                             where bus.CategoryId == selectedCategory.CategoryId && sta.StateId == selectedState.StateId
                                             select new BusinessViewModel { Business = bus, Address = adr, Content = bus.Content, Region = adr.Region };
                SearchData.CurrentSearchFilter += (","+selectedState.StateDisplayName);
            }
            // One State One Region by Category
            else if (state != "All States" && region != "All Regions")
            {
                Region selectedRegion = Context.Region.Where(x => x.RegionName == region).FirstOrDefault();
                selectedState = Context.State.Where(x => x.StateDisplayName == state).FirstOrDefault();
                businessViewModelList = from bus in Context.Business
                                            join adr in Context.Address on bus.AddressId equals adr.AddressId
                                            join sta in Context.State on adr.StateId equals sta.StateId
                                            where bus.CategoryId == selectedCategory.CategoryId && sta.StateId == selectedState.StateId && adr.RegionId == selectedRegion.RegionId
                                            select new BusinessViewModel { Business = bus, Address = adr, Content = bus.Content, Region = adr.Region };
                SearchData.CurrentSearchFilter += ("," + selectedState.StateDisplayName);
                SearchData.CurrentSearchFilter += ("," + selectedRegion.RegionName);
            }
            viewModel.BusinessList = businessViewModelList.ToList();
            viewModel.Category = category;
            viewModel.State = state;
            viewModel.Region = region;
            return viewModel;
        }

        [HttpPost]
        public List<string> GetRegionsByState(string state)
        {
            List<string> filteredRegions = new List<string>();

            if (!string.IsNullOrEmpty(state) && state != "All States")
            {                
                int stateID = Context.State.Where(x => x.StateDisplayName == state).FirstOrDefault().StateId;
                var regionsByState = Context.Region.Where(X => X.StateId == stateID).ToList();
                foreach (var region in regionsByState)
                {
                    filteredRegions.Add(region.RegionName);
                }
            }
            return filteredRegions;
            //return Json(filteredRegions);
        }
    }
}