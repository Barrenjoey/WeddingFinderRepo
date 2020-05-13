using System;
using System.Collections.Generic;
using System.Text;

namespace MailServerClient.Entities
{
    public class EmailMessage
    {
        public List<string> To { get; set; }

        public string From { get; set; }

        public string Subject { get; set; }

        public string Body { get; set; }

        public string BodyHTML { get; set; }
    }
}
