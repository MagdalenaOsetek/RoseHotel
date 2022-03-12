using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RoseHotel.Application.Abstractions;
using RoseHotel.Domain.Entities;
using RoseHotel.Domain.Repositories;

namespace RoseHotel.Application.Commands.Handlers
{
    public class AddRoomHandler : ICommandHandler<AddRoom>
    {
        private readonly IRoomRepository _roomRepository;
        private readonly IRoomTypeRepository _roomTypeRepository;

        public AddRoomHandler(IRoomRepository roomRepository,IRoomTypeRepository roomTypeRepository)
        {
            _roomRepository = roomRepository;
            _roomTypeRepository = roomTypeRepository;
        }

        public async Task HandleAsync(AddRoom command)
        {
            var (number, type) = command;

           var roomtype = await _roomTypeRepository.GetAsync(type);

            var room = new Room(command.RoomId, number,roomtype);
            await _roomRepository.AddAsync(room);

        }
    }
}
