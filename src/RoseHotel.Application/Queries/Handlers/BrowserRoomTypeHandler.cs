using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RoseHotel.Application.Abstractions;
using RoseHotel.Application.DTO;
using RoseHotel.Domain.Entities;
using RoseHotel.Domain.Repositories;

namespace RoseHotel.Application.Queries.Handlers
{
    internal sealed class BrowserRoomTypeHandler : IQueryHandler<BrowserRoomType, IReadOnlyCollection<RoomTypeDto>>
    {
        private readonly IRoomTypeRepository _roomTypeRepository;

        public BrowserRoomTypeHandler(IRoomTypeRepository roomTypeRepository)
        {
            _roomTypeRepository = roomTypeRepository;
        }
        public async Task<IReadOnlyCollection<RoomTypeDto>> HandleAsync(BrowserRoomType query)
        {
            var types = await _roomTypeRepository.BrowserAsync();

            return types.Select( x=> x.AsDto()).ToList();
        }


    }
}
