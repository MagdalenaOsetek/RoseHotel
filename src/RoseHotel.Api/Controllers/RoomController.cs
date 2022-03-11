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
    public class RoomController :BaseController
    {

        private readonly IDispatcher _dispatcher;

        public RoomController(IDispatcher dispatcher)
        {
            _dispatcher = dispatcher;
        }

        [HttpGet("free")]
        public async Task<ActionResult<IReadOnlyCollection<RoomDto>>> Free(BrowserFreeRooms query)
        {
            var rooms = await _dispatcher.QueryAsync(query);
            if (rooms.Count==0)
            {
                return Ok(new { message = "No free rooms left" });
            }
          return Ok(rooms);
        }

        [HttpPost("add")]
        public async Task<ActionResult> Add(AddRoom command)
        {
             await _dispatcher.SendAsync(command);
            return NoContent();
        }



    }
}
