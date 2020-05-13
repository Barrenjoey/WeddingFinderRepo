using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MailServerClient;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WeddingFinder.Models;
using WeddingFinder.ViewModels;


namespace WeddingFinder.Controllers
{
    public class ListBusinessController : BaseController
    {
        public string BackgroundImage { get; set; }

        public ListBusinessController()
        {
            BackgroundImage = "/images/background2.JPG";
        }

        public IActionResult Index()
        {
            ViewBag.SearchData = SearchData;
            ViewBag.ImgUrl = BackgroundImage;
            return View(PopulateDropdowns(new ListBusinessFormViewModel()));
        }

        [HttpPost]
        public IActionResult SubmitForm(ListBusinessFormViewModel formModel)
        {
            // Server side validation (in new project)
            if (!ModelState.IsValid)
            {
                ViewBag.SearchData = SearchData;
                ViewBag.ImgUrl = BackgroundImage;
                return View("Index", PopulateDropdowns(formModel));
            }

            // Email to inbox
            MailService mailService = new MailService();
            
            // Redirect to Thankyou page
            return Redirect("/ListBusiness/ThankYou");
        }

        private ListBusinessFormViewModel PopulateDropdowns(ListBusinessFormViewModel formViewModel)
        {            
            List<Category> categoryList = new List<Category>();
            List<State> stateList = new List<State>();
            categoryList = Context.Category.ToList();
            stateList = Context.State.ToList();
            formViewModel.CategoryList = categoryList;
            formViewModel.StateList = stateList;            

            return formViewModel;
        }

        [Route("ListBusiness/ThankYou")]
        public IActionResult ThankYou()
        {
            ViewBag.SearchData = SearchData;
            ViewBag.ImgUrl = BackgroundImage;
            return View();
        }
    }
}