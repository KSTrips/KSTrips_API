using KSTrips.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KSTrips_API.Services
{
    public interface IUserSecurityService
    {
        Task<User> AutenticarUserAsync(string email, string password);
        string GenerarTokenJWT(User usuarioInfo);
    }
}
