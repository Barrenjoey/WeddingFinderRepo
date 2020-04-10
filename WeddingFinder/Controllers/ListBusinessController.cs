using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WeddingFinder.Controllers
{
    public class ListBusinessController : BaseController
    {
        public IActionResult Index()
        {
            ViewBag.SearchData = SearchData;
            ViewBag.ImgUrl = "/images/background2.JPG";
            return View();
        }
    }
}