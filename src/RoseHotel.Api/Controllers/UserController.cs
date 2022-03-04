using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RoseHotel.Application.Abstractions;
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

        //[AllowAnonymous]
        [HttpPost("authenticate")]
        public async Task<ActionResult<UserDto>> Authenticate(GetUser query)
        {
            var user = await _dispatcher.QueryAsync(query);
            if (user == null)
            {
                return BadRequest(new { message = "Username or password is incorrect" });
            }
            return Ok(user);
        }
    }
}
