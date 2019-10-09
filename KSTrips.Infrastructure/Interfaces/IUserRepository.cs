using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using KSTrips.Domain.Entities;

namespace KSTrips.Infrastructure.Interfaces
{
    public interface IUserRepository
    {
        Task<List<User>> GetUsers();
    }
}
