using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RoseHotel.Application.Abstractions;
using RoseHotel.Application.Commands;

namespace RoseHotel.Api.Controllers
{
    public class BasketController : BaseController
    {
        private readonly IDispatcher _dispatcher;

        public BasketController(IDispatcher dispatcher)
        {
            _dispatcher = dispatcher;
        }


        [HttpPost]
       // [SwaggerOperation("Add wallet to the database")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Post(ChooseDateToBasket command)
        {
            await _dispatcher.SendAsync(command);
            return NoContent();
          //  return CreatedAtAction(nameof(Get), new { walletId = command.WalletId }, null);
        }
    }
}
