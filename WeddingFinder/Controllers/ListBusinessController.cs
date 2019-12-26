using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WeddingFinder.Controllers
{
    public class ListBusinessController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.ImgUrl = "/images/background2.JPG";
            return View();
        }
    }
}