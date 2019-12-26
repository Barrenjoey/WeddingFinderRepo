using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WeddingFinder.Models;

namespace WeddingFinder.Controllers
{
    public class VenuesController : BaseController
    {
        //https://localhost:44348/venues/?searchFilters=&state=NSW&region=Hunter%20Valley
        public IActionResult Index(string state, string region)
        {
            string controllerName = this.ControllerContext.RouteData.Values["controller"].ToString();
            ViewBag.SearchData = SearchData;
            ViewBag.ImgUrl = "/Images/background.jpeg";
            // Filter by Search Strings
            if (!string.IsNullOrEmpty(state) && !string.IsNullOrEmpty(region))
            {
                return View("Category", GetCategoriesViewModelWithSearch(controllerName, state, region));                
            }

            // If no search string then return all                                                
            return View("Category", GetCategoriesViewModel(controllerName));                       
        }

        //[HttpGet("/Venues/{searchString}/")]
        [Route("Venues/{businessName}")]
        public IActionResult Business(string businessName)
        {
            string name = RouteData.Values["Controller"].ToString();
            Business business = GetBusinessByName(businessName);
            if (business == null || business.ContentId == null)
            {
                return Redirect("/");
            }
            Content content = GetContentbyID(business.ContentId);

            ViewBag.Title = business.BusinessName;
            ViewBag.ImgUrl = "/Images/background.jpeg";
            ViewBag.SearchData = SearchData;

            return View("Business", content);            // Need to put in businessViewModel
        }
        
    }
}