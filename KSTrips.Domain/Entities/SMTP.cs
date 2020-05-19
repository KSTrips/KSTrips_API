using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace KSTrips.Domain.Entities
{
    public class SMTP : BaseEntity
    {
        public string SMTPServer { get; set; }
        public int Port { get; set; }
        public string Host { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

    }
}
