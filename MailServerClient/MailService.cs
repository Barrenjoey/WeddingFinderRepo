using MailServerClient.Entities;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace MailServerClient
{
    public class MailService
    {
        private string endpoint;
        private string apiKey;

        public string SendMail(EmailMessage mail)
        {
            // TODO - Add App settings to get endpoint and api key
            endpoint = @"http://127.0.0.1:5000/api/email/send";
            apiKey = "e0ab9414-ccd3-42c4-935b-f5951f80b1b9";
            string status = "Something went wrong with calling the Mail Server";

            HttpContent mailContent = new StringContent(JsonSerializer.Serialize(mail));

            // Setup Api call with endpoint
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Add("User-Agent", "WeddingFinder Website");
                client.DefaultRequestHeaders.Add("x-api-key", apiKey);

                // Post call
                HttpResponseMessage result = client.PostAsync(endpoint, mailContent).Result;
            }            

            // Retrieve result and throw any errors

            return status;
        }             


    }
}
