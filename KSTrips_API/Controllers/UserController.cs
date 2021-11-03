using System;
using KSTrips.Application.Interfaces;
using KSTrips.Domain.Entities;
using KSTrips_API.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace KSTrips_API.Controllers
{
    [Route("v1/Users")]
    [ApiController]
    
    public class UserController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IUserService _userServices;
        private readonly IUserSecurityService _userSecurityService;

        public UserController(IUserService userServices, IConfiguration configuration, IUserSecurityService userSecurityService)
        {
            _userServices = userServices;
            _configuration = configuration;
            _userSecurityService = userSecurityService;
        }

        [HttpGet()]
        [Authorize]
        public async Task<IActionResult> GetUsers()
        {
            try
            {
                List<User> result = await _userServices.GetUsers();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

           
        }

        [HttpGet("{userId}")]
        [Authorize]
        public async Task<IActionResult> GetUserByEmail(string email)
        {
            try
            {
                List<User> result = await _userServices.GetUserByEmail(email);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
            
        }

        // POST api/saveUsers
        [HttpPost("SaveUser")]
        [Authorize]
        public IActionResult SaveUsers([FromBody] User dataUser)
        {
            try
            {
                var result = _userServices.SaveUser(dataUser);

                if (result)
                    return Ok();

                return BadRequest("Error: al guardar el usuario");
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
            

        }

        // POST api/updateUsers
        [HttpPut("UpdateUsers")]
        [Authorize]
        public IActionResult UpdateUsers([FromBody] IEnumerable<User> dataUsers)
        {
            try
            {
                var result = _userServices.UpdateUsers(dataUsers);

                if (result)
                    return Ok();

                return BadRequest("Error: al actualizar los usuarios");
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
            

        }

        // POST api/updateUsers
        [HttpPut("UpdateSpecificUser")]
        [Authorize]
        public IActionResult UpdateSpecificUser([FromBody] User dataUser)
        {
            try
            {
                var result = _userServices.UpdateSpecificUser(dataUser);

                if (result)
                    return Ok();

                return BadRequest("Error: al actualizar el usuario " + dataUser.UserName);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }


        }

        [HttpPost("Login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login(string email, string password)
        {
            //UserSecurityService uss = new UserSecurityService(_configuration, _userServices);
            var _userInfo = await _userSecurityService.AutenticarUserAsync(email,password);
            if (_userInfo != null)
            {
                return Ok(new { token = _userSecurityService.GenerarTokenJWT(_userInfo) });
            }
            else
            {
                return Unauthorized();
            }
        }

        [HttpPost("RegisterUser")]
        [AllowAnonymous]
        public IActionResult RegisterUser([FromBody] User user)
        {
            try
            {
                var result = _userServices.SaveUser(user);

                if (result)
                    return Ok();

                return BadRequest("Error: al guardar el usuario ");
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

        }
    }
}