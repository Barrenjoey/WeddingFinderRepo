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
            if (true)
            {

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
                $"<p><b>Subrub: </b> {model.Suburb}<p>";

            var x = @"string FirstName       
            string LastName
            string Email
            string ContactNumber
            string Street
            string Suburb
            string Postcode
            string State
            string Region
            string BusinessName
            string Category
            string Instagram
            string Facebook
            string Website
            string ShortDescription
            string FullDescription
            bool TermsAndConditions
            bool HasSeveralRegions
            List<int> ServicedRegions
            FormFile Upload";

            return message;
        }
    }
}