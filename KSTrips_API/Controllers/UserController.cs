using System;
using KSTrips.Application.Interfaces;
using KSTrips.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KSTrips_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly IUserService _userServices;

        public UserController(IUserService userServices)
        {
            _userServices = userServices;
        }

        [HttpGet()]
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

        [HttpGet("{authZeroId}")]
        public async Task<IActionResult> GetUserByAuthZeroId(string authZeroId)
        {
            try
            {
                List<User> result = await _userServices.GetUserByAuthZeroId(authZeroId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
            
        }

        // POST api/saveUsers
        [HttpPost("SaveUsers")]
        public IActionResult SaveUsers([FromBody] User dataUsers)
        {
            try
            {
                var result = _userServices.SaveUsers(dataUsers);

                if (result)
                    return Ok();

                return BadRequest("Error: al guardar los usuarios");
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
            

        }

        // POST api/updateUsers
        [HttpPut("UpdateUsers")]
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
        public IActionResult UpdateSpecificUser([FromBody] User dataUser)
        {
            try
            {
                var result = _userServices.UpdateSpecificUser(dataUser);

                if (result)
                    return Ok();

                return BadRequest("Error: al actualizar el usuario " + dataUser.Name);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }


        }

    }
}