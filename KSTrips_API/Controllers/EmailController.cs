using KSTrips.Application.Interfaces;
using KSTrips.Domain.Transversal;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Threading.Tasks;

namespace KSTrips_API.Controllers
{
    [Route("v1/Emails")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        private readonly IEmailService _iemailServices;

        public EmailController(IEmailService iemailServices)
        {
            _iemailServices = iemailServices;
        }

           

        [HttpPost]
        public IActionResult SendMail([FromBody]Email email)
        {
            try
            {
                _iemailServices.sendEmail(email);

                return Ok();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}