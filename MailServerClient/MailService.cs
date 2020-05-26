using MailServerClient.Entities;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace MailServerClient
{
    public class MailService
    {
        private string _endpoint;
        private string _apiKey;

        public MailService(string apiKey, string endpoint)
        {
            _apiKey = apiKey;
            _endpoint = endpoint;
        }

        public string SendMail(EmailMessage mail)
        {
            // TODO - Add App settings to get endpoint and api key
            //_endpoint = @"http://127.0.0.1:5000/api/email/send";
            //_apiKey = "e0ab9414-ccd3-42c4-935b-f5951f80b1b9";
            

            string status = "Something went wrong with calling the Mail Server";
            var testJson = JsonSerializer.Serialize(mail);
            HttpContent mailContent = new StringContent(testJson, Encoding.UTF8);            
            mailContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            // Setup Api call with endpoint
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Add("User-Agent", "WeddingFinder Website");
                client.DefaultRequestHeaders.Add("x-api-key", _apiKey);                

                // Post call
                HttpResponseMessage result = client.PostAsync(_endpoint, mailContent).Result;
                status = result.StatusCode.ToString();
            }

            // Retrieve result and throw any errors
            status = status.ToLower();
            return status;
        }                     

    }
}
