using System.Collections.Generic;
using System.Threading.Tasks;
using KSTrips.Domain.Entities;

namespace KSTrips.Application.Interfaces
{
    public interface IUserService
    {
        Task<List<User>> GetUsers();
        Task<List<User>> GetUserByEmail(string email);
        bool SaveUser(User dataUser);
        bool UpdateUsers(IEnumerable<User> dataUsers);
        bool UpdateSpecificUser(User dataUser);

    }
}
