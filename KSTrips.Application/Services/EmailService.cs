using KSTrips.Application.Interfaces;
using KSTrips.Domain.Entities;
using KSTrips.Domain.Transversal;
using KSTrips.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace KSTrips.Application.Services
{
    public class EmailService : IEmailService
    {

        private readonly IUnitOfWork _unitOfWork;
        public EmailService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public Task<SMTP> getSMTPServer()
        {
            throw new NotImplementedException();
        }

        public void sendEmail(Email email)
        {
            try
            {
                var SMTP =  _unitOfWork.SMTPRepository.GetSMTPServer();

                string Email = SMTP.Email;
                string Password = SMTP.Password;
                string smtpServer = SMTP.SMTPServer;
                int port = SMTP.Port;

                SmtpClient client = new SmtpClient(smtpServer, port)
                {
                    UseDefaultCredentials = false,
                    EnableSsl = true,
                    Credentials = new System.Net.NetworkCredential(Email, Password),
                    DeliveryMethod = SmtpDeliveryMethod.Network
                };

                MailMessage mailMessage = new MailMessage (email.From, Email) ;
                
                mailMessage.To.Add(Email);

                mailMessage.Body = email.Message;
                mailMessage.Subject = email.Name + " - "+ email.Subject;

                client.SendMailAsync(mailMessage);
               
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
