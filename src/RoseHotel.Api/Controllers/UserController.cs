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
        {
            var user = await _dispatcher.QueryAsync(query);
            if (user == null)
            {
                return BadRequest(new { message = "User not found" });
            }
            return Ok(user);
        }

        [HttpGet("authenticate")]
        public async Task<ActionResult<UserDto>> Authenticate(AuthenticateUser query)
        {
            var user = await _dispatcher.QueryAsync(query);
            if (user == null)
            {
                return BadRequest(new { message = "Username or password is incorrect" });
            }
            return Ok(user);
        }


        [HttpGet("browserReservations")]
        public async Task<ActionResult<IReadOnlyCollection<ReservationDto>>> BrowserReservations(BrowserUserReservations query)
        {
            var reservations = await _dispatcher.QueryAsync(query);
            if (reservations.Count==0)
            {
                return Ok(new { message = "No reservations yet found" });
            }
            return Ok(reservations);
        }


        [HttpPost("register")]
        public async Task<ActionResult<UserDto>> Register(RegisterUser command)
        {
            await _dispatcher.SendAsync(command);
            return CreatedAtAction(nameof(Get),"/user",null);
        }

        [HttpPut("verify")]
        public async Task<ActionResult> Verify(VerifyUser command)
        {
            await _dispatcher.SendAsync(command);
            return NoContent();
        }

        [HttpPut("upsertGuest")]
        public async Task<ActionResult> upsertGuest(UpsertGuestToUser command)
        {
            await _dispatcher.SendAsync(command);
            return NoContent();
        }


        
    }
}
