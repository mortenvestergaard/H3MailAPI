using MailKit.Net.Smtp;
using MimeKit;
using CRMailAPI.Models;
using CRMailAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;

namespace CRMailAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {

        private readonly IMailService _mailService;
        public EmailController(IMailService mailService)
        {
            _mailService = mailService;
        }

        [HttpPost]
        [Route("Send")]
        public async Task<IActionResult> Send([FromBody] MailRequest request)
        {
            // Receives data from Angular!
            await _mailService.SendEmailAsync(request);
            return Ok();

        }
    }
}
