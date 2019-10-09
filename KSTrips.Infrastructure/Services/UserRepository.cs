using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using KSTrips.Domain.Entities;
using KSTrips.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace KSTrips.Infrastructure.Services
{
    public class UserRepository : IUserRepository
    {
        private TripContext Context { get ; }

        public UserRepository(TripContext context)
        {
            Context = context;
        }

        public async Task<List<User>> GetUsers()
        {
            return await  Context.Users.ToListAsync();
        }
    }
}
