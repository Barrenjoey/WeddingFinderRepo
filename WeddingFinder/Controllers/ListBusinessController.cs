using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MailServerClient;
using MailServerClient.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using WeddingFinder.Models;
using WeddingFinder.ViewModels;


namespace WeddingFinder.Controllers
{
    public class ListBusinessController : BaseController
    {
        private readonly IConfiguration _config;
        public string BackgroundImage { get; set; }

        public ListBusinessController(IConfiguration config)
        {
            _config = config;
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

            // TODO: Check for existing businesses with the same name / email. Return to view if exists.
            if (CheckIfAlreadyExists(formModel.BusinessName, formModel.Email))
            {                
                ViewBag.SearchData = SearchData;
                ViewBag.ImgUrl = BackgroundImage;
                return View("Index", PopulateDropdowns(formModel));
            }

            // Create Email
            EmailMessage message = new EmailMessage();                        
            message = CreateMessageFromFormViewModel(message, formModel);
            
            // Connect to Mail Service and send
            string apiKey = _config.GetValue(typeof(string), "AppSettings:MailServerApiKey").ToString();
            string endpoint = _config.GetValue(typeof(string), "AppSettings:MailServerEndpoint").ToString();
            MailService mailService = new MailService(apiKey, endpoint);
            mailService.SendMail(message);
            
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

        private EmailMessage CreateMessageFromFormViewModel(EmailMessage message, ListBusinessFormViewModel model)
        {
            // Get Email Recipient
            List<string> recipients = new List<string>();
            string listBusinessRecipient = _config.GetValue(typeof(string), "AppSettings:ListBusinessRecipient").ToString();
            recipients.Add(listBusinessRecipient);
            message.To = recipients;

            message.From = "Test@gmail.com"; //Doesnt do anythin

            message.Subject = "Application - " + model.BusinessName;

            message.Body = "";
            message.BodyHTML = $"<h3>{model.BusinessName}</h3><br>" +
                $"<p><b>First Name: </b> {model.FirstName}<p>" +
                $"<p><b>Last Name: </b> {model.LastName}<p>" +
                $"<p><b>Email: </b> {model.Email}<p>" +
                $"<p><b>Contact Number: </b> {model.ContactNumber}<p>" +
                $"<p><b>Street: </b> {model.Street}<p>" +
                $"<p><b>Subrub: </b> {model.Suburb}<p>" +
                $"<p><b>Postcode: </b> {model.Postcode}<p>" +
                $"<p><b>State: </b> {model.State}<p>" +                
                $"<p><b>Region: </b> {model.Region}<p>" +
                $"<p><b>ServicedRegions: </b> {model.ServicedRegions}<p>" +
                $"<p><b>BusinessName: </b> {model.BusinessName}<p>" +
                $"<p><b>Category: </b> {model.Category}<p>" +
                $"<p><b>Instagram: </b> {model.Instagram}<p>" +
                $"<p><b>Facebook: </b> {model.Facebook}<p>" +
                $"<p><b>Website: </b> {model.Website}<p>" +
                $"<p><b>ShortDescription: </b> {model.ShortDescription}<p>" +
                $"<p><b>FullDescription: </b> {model.FullDescription}<p>" +
                $"<p><b>Image: </b> {model.Upload}<p>";            

            return message;
        }

        private bool CheckIfAlreadyExists(string business, string email)
        {
            bool exists = false;
            var businessName = Context.Business.Where(x => x.BusinessName == business);
            var emailAddress = Context.Contact.Where(x => x.Email == email);
            if (businessName != null)
            {
                ModelState.AddModelError("Exists", "The Business already exists");
                exists = true;
            }
            if (email != null)
            {
                ModelState.AddModelError("Exists", "The Email already exists");
                exists = true;
            }
            return exists;
        }
    }
}