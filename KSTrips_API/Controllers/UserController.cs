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
            List<User> result = await _userServices.GetUsers();
            return Ok(result);
        }

        [HttpGet("{authZeroId}")]
        public async Task<IActionResult> GetUserByAuthZeroId(string authZeroId)
        {

            List<User> result = await _userServices.GetUserByAuthZeroId(authZeroId);
            return Ok(result);
        }

        // POST api/saveUsers
        [HttpPost("SaveUsers")]
        public IActionResult SaveUsers([FromBody] User dataUsers)
        {
            var result = _userServices.SaveUsers(dataUsers);

            if (result)
                return Ok();

            return BadRequest("Error: al guardar los usuarios");

        }

        // POST api/updateUsers
        [HttpPost("UpdateUsers")]
        public IActionResult UpdateUsers([FromBody] IEnumerable<User> dataUsers)
        {
            var result = _userServices.UpdateUsers(dataUsers);

            if (result)
                return Ok();

            return BadRequest("Error: al actualizar los usuarios");

        }

    }
}