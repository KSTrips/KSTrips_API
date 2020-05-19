using KSTrips.Domain.Entities;
using KSTrips.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace KSTrips.Infrastructure.Services
{
    public class SMTPRepository : ISMTPRepository
    {
        private TripContext Context { get; }

        public SMTPRepository(TripContext context)
        {
            Context = context;
        }

        public SMTP GetSMTPServer()
        {
            return Context.SMTPServer.Find(1);
        }
    }
}
