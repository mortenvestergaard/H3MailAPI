using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRMailAPI.Models
{
    // This class represents MailRequest!
    public class MailRequest
    {
        // Create auto implemented properties with get and set accessor!
        public string ReplyFrom { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
    }
}
