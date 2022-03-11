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

        public AddRoomHandler(IRoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }

        public async Task HandleAsync(AddRoom command)
        {
            var (number, type, price, capacity) = command;

            var room = new Room(command.RoomId, number, type, price, capacity);
            await _roomRepository.AddAsync(room);

        }
    }
}
