using MailServerClient;
using MailServerClient.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace MailServerClientTests
{
    [TestClass]
    public class UnitTests
    {
        [TestMethod]
        public void SendMail_1()
        {
            var endpoint = @"http://127.0.0.1:5000/api/email/send";
            var apiKey = "e0ab9414-ccd3-42c4-935b-f5951f80b1b9";

            MailService service = new MailService(apiKey, endpoint);
            EmailMessage mail = new EmailMessage();
            List<string> recipients = new List<string>();

            recipients.Add("J_vdm@hotmail.com");
            mail.To = recipients;
            mail.From = "Test@gmail.com";
            mail.Subject = "Test Email - Ignore";
            mail.Body = "This is the body";
            mail.BodyHTML = "<p>This is an html body</p>";

            var status = service.SendMail(mail);

            Assert.AreEqual("created", status);
        }
    }
}
