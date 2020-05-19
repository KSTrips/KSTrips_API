using KSTrips.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace KSTrips.Infrastructure.Services
{
    public class RoleRepository : IRoleRepository
    {
        private TripContext Context { get; }

        public RoleRepository(TripContext context)
        {
            Context = context;
        }
    }
}
