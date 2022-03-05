using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RoseHotel.Application.Abstractions;
using RoseHotel.Application.Commands;
using RoseHotel.Application.DTO;
using RoseHotel.Application.Queries;

namespace RoseHotel.Api.Controllers
{
    public class UserController : BaseController 
    {

        private readonly IDispatcher _dispatcher;

        public UserController(IDispatcher dispatcher)
        {
            _dispatcher = dispatcher;
        }

        [HttpGet]
        public async Task<ActionResult<UserDto>> Get( GetUser query)
              => Ok(await _dispatcher.QueryAsync(query));

        [HttpGet("authenticate")]
        public async Task<ActionResult<UserDto>> Authenticate([FromQuery] GetUser query)
        {
            var user = await _dispatcher.QueryAsync(query);
            if (user == null)
            {
                return BadRequest(new { message = "Username or password is incorrect" });
            }
            return Ok(user);
        }


        [HttpPost("register")]
        public async Task<ActionResult<UserDto>> Register(RegisterUser command)
        {
            await _dispatcher.SendAsync(command);
            return CreatedAtAction(nameof(Get), null);
        }

        [HttpPut("verify")]
        public async Task<ActionResult> Verify(VerifyUser command)
        {
            await _dispatcher.SendAsync(command);
            return NoContent();
        }

        [HttpPut("addGuest")]
        public async Task<ActionResult> AddGuest(AddGuestToUser command)
        {
            await _dispatcher.SendAsync(command);
            return NoContent();
        }



    }
}
