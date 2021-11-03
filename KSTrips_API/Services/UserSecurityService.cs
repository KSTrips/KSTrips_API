using KSTrips.Application.Interfaces;
using KSTrips.Domain.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace KSTrips_API.Services
{
    public class UserSecurityService
    {
        /// <summary>
        ///     Accessor to config file
        /// </summary>
        private readonly IConfiguration _configuration;
        private readonly IUserService _userServices;

        public UserSecurityService(IConfiguration configuration, IUserService userServices)
        {
            _configuration = configuration;
            _userServices = userServices;
        }

        /// <summary>
        ///  Comprobamos si el usuario exsite en BD
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public async Task<User> AutenticarUserAsync(string email,string password)
        {
            // AQUÍ LA LÓGICA DE AUTENTICACIÓN //
            var userExists = await _userServices.GetUserByEmail(email);
            if(userExists != null)
            {
                return userExists.FirstOrDefault();
            }

            return null;

        }

        /// <summary>
        /// Generamos el Token
        /// </summary>
        /// <param name="usuarioInfo"></param>
        /// <returns></returns>
        public string GenerarTokenJWT(User usuarioInfo)
        {
            // CREAMOS EL HEADER //
            var _symmetricSecurityKey = new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(_configuration["JWT:EncriptionKey"])
                );
            var _signingCredentials = new SigningCredentials(
                    _symmetricSecurityKey, SecurityAlgorithms.HmacSha256
                );
            var _Header = new JwtHeader(_signingCredentials);

            // CREAMOS LOS CLAIMS //
            var _Claims = new[] {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.NameId, usuarioInfo.Id.ToString()),
                new Claim("UserName", usuarioInfo.UserName),
                new Claim("Password", usuarioInfo.Password),
                new Claim(JwtRegisteredClaimNames.Email, usuarioInfo.Email)//,
                //new Claim(ClaimTypes.Role, usuarioInfo.Rol)
            };

            // CREAMOS EL PAYLOAD //
            var _Payload = new JwtPayload(
                    issuer: _configuration["JWT:Issuer"],
                    audience: _configuration["JWT:Audience"],
                    claims: _Claims,
                    notBefore: DateTime.UtcNow,
                    // Expira a la 10 minutos.
                    expires: DateTime.UtcNow.AddMinutes(10)
                );

            // GENERAMOS EL TOKEN //
            var _Token = new JwtSecurityToken(
                    _Header,
                    _Payload
                );

            return new JwtSecurityTokenHandler().WriteToken(_Token);
        }

    }
}
