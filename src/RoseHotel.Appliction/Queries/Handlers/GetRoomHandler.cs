using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RoseHotel.Appliction.Abstractions;
using RoseHotel.Appliction.DTO;
using RoseHotel.Domain.Repositories;

namespace RoseHotel.Appliction.Queries.Handlers
{
    class GetRoomHandler : IQueryHandler<GetRoom, RoomDto>
    {
        private readonly IRoomRepository _roomRepository;

        public GetRoomHandler (IRoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }
        public async Task<RoomDto> HandleAsync(GetRoom query)
        {
            var room = await _roomRepository.GetAsync(query.RoomId);

            return room.AsDto();
        }
    }
}
