using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RoseHotel.Application.Abstractions;
using RoseHotel.Application.Exceptions;
using RoseHotel.Domain.Entities;
using RoseHotel.Domain.Repositories;

namespace RoseHotel.Application.Commands.Handlers
{
    public class AddRoomTypeHandler : ICommandHandler<AddRoomType>
    {
        private readonly IRoomTypeRepository _roomTypeRepository;

        public AddRoomTypeHandler(IRoomTypeRepository roomTypeRepository)
        {
            _roomTypeRepository = roomTypeRepository;
        }
        public async Task HandleAsync(AddRoomType command)
        {
            var (type, price, capacity) = command;

            var r = await _roomTypeRepository.ExistAsync(type, price, capacity);

            if(r)
            {
                throw new RoomTypeAlreadyExists(type, price ,capacity);
            }
            var roomType = new RoomType(command.RoomTypeId, type, price, capacity);

            await _roomTypeRepository.AddAsync(roomType);

        }
    }
}
