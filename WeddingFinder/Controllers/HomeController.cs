using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WeddingFinder.Models;

namespace WeddingFinder.Controllers
{
    public class HomeController : BaseController
    {
        public IActionResult Index()
        {
            ViewBag.ImgUrl = "/images/background2.2.png";       
            ViewBag.SearchData = SearchData;
            return View();            
        }

        public IActionResult Privacy()
        {
            ViewBag.SearchData = SearchData;
            return View();
        }
        
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
