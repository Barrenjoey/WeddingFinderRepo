using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WeddingFinder.Models;
using WeddingFinder.ViewModels;

namespace WeddingFinder.Controllers
{
    public class ListBusinessController : BaseController
    {
        public IActionResult Index()
        {
            ViewBag.SearchData = SearchData;
            ViewBag.ImgUrl = "/images/background2.JPG";
            return View(PopulateDropdowns());
        }

        [HttpPost]
        public IActionResult SubmitForm(ListBusinessFormViewModel formModel)
        {
            // Server side validation (in new project)
            // - Category Not Equal default choice.
            if (formModel.Category == null || formModel.Category == "Please select one")
            {
                return View("Index", formModel);                
            }            


            // Email to inbox


            // Redirect to Thankyou page
            return Content("test");
        }

        private ListBusinessFormViewModel PopulateDropdowns()
        {
            ListBusinessFormViewModel formViewModel = new ListBusinessFormViewModel();
            List<Category> categoryList = new List<Category>();
            categoryList = Context.Category.ToList();
            formViewModel.CategoryList = categoryList;
            //formViewModel.CategoryList = new SelectList(categoryList, "CategoryId", "CategoryName");
            //formViewModel.CategoryList.Prepend(new SelectListItem { Text = "Please choose one", Value = "" });

            return formViewModel;
        }
    }
}