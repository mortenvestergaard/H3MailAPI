using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRMailAPI.Settings
{
    // This class represents MailSettings!
    public class MailSettings
    {
        // Create auto implemented properties with get and set accessor!
        public string ToEmail { get; set; }
        public string Mail { get; set; }
        public string DisplayName { get; set; }
        public string Password { get; set; }
        public string Host { get; set; }
        public int Port { get; set; }
    }
}
