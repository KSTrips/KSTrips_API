using KSTrips.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace KSTrips.Infrastructure.Services
{
    public class UserRoleRepository : IUserRoleRepository
    {
        private TripContext Context { get; }

        public UserRoleRepository(TripContext context)
        {
            Context = context;
        }
    }
}
