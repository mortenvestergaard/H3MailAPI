using MailKit;
using CRMailAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRMailAPI.Services
{
    // This interface represents IMailService!
    public interface IMailService
    {
        // Method with empty body!
        Task SendEmailAsync(MailRequest mailRequest);
    }
}
