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
    public class BasketController : BaseController
    {
        private readonly IDispatcher _dispatcher;

        public BasketController(IDispatcher dispatcher)
        {
            _dispatcher = dispatcher;
        }



        [HttpGet]
        public async Task<ActionResult<BasketDto>> Get(GetBasket query)
              => Ok(await _dispatcher.QueryAsync(query));


        [HttpPost("chooseDate")]
        public async Task<IActionResult> ChooseDate(ChooseDateToBasket command)
        {
            await _dispatcher.SendAsync(command);
            return NoContent();
          
        }
        

        [HttpPut("addGuest")]
        public async Task<IActionResult> AddGuest(AddGuestToBasket command)
        {
            await _dispatcher.SendAsync(command);
            return NoContent();

        }



        [HttpPut("addRoom")]
        public async Task<IActionResult> AddRoom(AddRoomToBasket command)
        {
            await _dispatcher.SendAsync(command);
            return NoContent();

        }


  

    }
}
