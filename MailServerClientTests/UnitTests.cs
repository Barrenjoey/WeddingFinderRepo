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
            MailService service = new MailService();
            EmailMessage mail = new EmailMessage();
            List<string> recipients = new List<string>();

            recipients.Add("J_vdm@hotmail.com");
            mail.To = recipients;
            mail.From = "Test@gmail.com";
            mail.Body = "This is the body";
            mail.BodyHTML = "<p>This is an html body</p>";

            service.SendMail(mail);
        }
    }
}
