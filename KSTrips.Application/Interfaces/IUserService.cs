using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using KSTrips.Domain.Entities;
using KSTrips.Domain.Transversal;
using KSTrips.Domain.Transversal.Response;

namespace KSTrips.Application.Interfaces
{
    public interface IUserService
    {
        Task<List<User>> GetUsers();
        Task<List<User>> GetUserByAuthZeroId(string authZeroId);
        bool SaveUsers(User dataUsers);
        bool UpdateUsers(IEnumerable<User> dataUsers);

    }
}
