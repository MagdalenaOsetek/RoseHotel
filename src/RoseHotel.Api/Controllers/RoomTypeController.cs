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
    public class RoomTypeController : BaseController
    {

        private readonly IDispatcher _dispatcher;

        public RoomTypeController(IDispatcher dispatcher)
        {
            _dispatcher = dispatcher;
        }

        [HttpGet("browser")]
        public async Task<ActionResult<IReadOnlyCollection<RoomTypeDto>>> Browser(BrowserRoomType query)
            => Ok(await _dispatcher.QueryAsync(query));
     
        [HttpPost("add")]
        public async Task<ActionResult> Add(AddRoomType command)
        {
            await _dispatcher.SendAsync(command);
            return NoContent();
        }
    }
}
