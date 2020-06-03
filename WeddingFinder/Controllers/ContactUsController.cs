using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MailServerClient;
using MailServerClient.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using WeddingFinder.ViewModels;

namespace WeddingFinder.Controllers
{
    public class ContactUsController : BaseController
    {
        private readonly IConfiguration _config;
        public string BackgroundImage { get; set; }
        public ContactUsController(IConfiguration config)
        {
            _config = config;
            BackgroundImage = "/images/background2.JPG";
        }
        public IActionResult Index()
        {
            ViewBag.SearchData = SearchData;
            ViewBag.ImgUrl = BackgroundImage;

            ContactUsViewModel model = new ContactUsViewModel();
            var contactUsCategories = _config.GetValue(typeof(string), "AppSettings:ContactUsCategories").ToString().Split(",");
            model.Categories = contactUsCategories.ToList();
            return View(model);
        }

        [HttpPost]
        public IActionResult SubmitForm(ContactUsViewModel formModel)
        {
            // Server side validation (in new project)
            if (!ModelState.IsValid)
            {
                ViewBag.SearchData = SearchData;
                ViewBag.ImgUrl = BackgroundImage;
                return View("Index", formModel);
            }
            // Create Email
            EmailMessage message = new EmailMessage();
            message = CreateMessageFromFormViewModel(message, formModel);

            // Connect to Mail Service and send
            string apiKey = _config.GetValue(typeof(string), "AppSettings:MailServerApiKey").ToString();
            string endpoint = _config.GetValue(typeof(string), "AppSettings:MailServerEndpoint").ToString();
            MailService mailService = new MailService(apiKey, endpoint);
            mailService.SendMail(message);

            return Redirect("/"); // TODO - Redirect to Thankyou Message
        }

        private EmailMessage CreateMessageFromFormViewModel(EmailMessage message, ContactUsViewModel model)
        {
            // Get Email Recipient
            List<string> recipients = new List<string>();
            string listBusinessRecipient = _config.GetValue(typeof(string), "AppSettings:ListBusinessRecipient").ToString();
            recipients.Add(listBusinessRecipient);
            message.To = recipients;

            message.From = "Test@gmail.com"; //Doesnt do anythin

            message.Subject = model.Category + " - "  + model.Email;

            message.Body = "";
            message.BodyHTML = $"<p><b> First Name: </b> { model.FirstName}<p> " +
                $"<p><b>Last Name: </b> {model.LastName}<p>" +
                $"<p><b>Email: </b> {model.Email}<p>" +
                $"<p><b>Contact Number: </b> {model.ContactNumber}<p>" +
                $"<p><b>Description: </b> {model.Description}<p>";

            return message;
        }
    }
}