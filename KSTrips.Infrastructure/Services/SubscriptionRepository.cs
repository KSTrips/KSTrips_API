using KSTrips.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace KSTrips.Infrastructure.Services
{
    public class SubscriptionRepository : ISubscriptionRepository
    {
        private TripContext Context { get; }

        public SubscriptionRepository(TripContext context)
        {
            Context = context;
        }
    }
}
