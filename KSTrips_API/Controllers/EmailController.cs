using System;
using System.Runtime.InteropServices.ComTypes;
using System.Threading.Tasks;
using KSTrips.Domain.Transversal;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Net.Mail;

namespace KSTrips_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> SendMail([FromBody]Email email)
        {
            try
            {
                var Email = "transportesvm371@gmail.com";
                var Password = "transvm371";

                var client = new System.Net.Mail.SmtpClient("smtp.gmail.com", 587)
                {
                    UseDefaultCredentials = false,
                    EnableSsl = true,
                    Credentials = new System.Net.NetworkCredential(Email, Password)
                };

                var mailMessage = new System.Net.Mail.MailMessage { From = new System.Net.Mail.MailAddress(email.From,email.Name) };

                email.To = Email;
                mailMessage.To.Add(email.To);

                mailMessage.Body = email.Message;
                mailMessage.Subject = email.Subject;

                mailMessage.BodyEncoding = System.Text.Encoding.UTF8;
                mailMessage.SubjectEncoding = System.Text.Encoding.UTF8;

                await client.SendMailAsync(mailMessage);

                 return Ok();
            }
            catch (Exception ex)
            {
                throw ex;
            }
          
        }
    }
}