using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RoseHotel.Application.Abstractions;
using RoseHotel.Application.Commands;

namespace RoseHotel.Api.Controllers
{
    public class ReservationController :BaseController
    {

  
        private readonly IDispatcher _dispatcher;

        public ReservationController(IDispatcher dispatcher)
        {
            _dispatcher = dispatcher;
        }


        [HttpPost("confirm")]
        public async Task<IActionResult> Confirm(ConfirmReservation command)
        {
            await _dispatcher.SendAsync(command);
            return NoContent();

        }


        [HttpPut("pay")]
        public async Task<IActionResult> Pay(PayReservation command)
        {
            await _dispatcher.SendAsync(command);
            return NoContent();

        }

        [HttpDelete("cancel")]
        public async Task<IActionResult> Cancel(CancelReservation command)
        {
            await _dispatcher.SendAsync(command);
            return NoContent();

        }
    }
}
