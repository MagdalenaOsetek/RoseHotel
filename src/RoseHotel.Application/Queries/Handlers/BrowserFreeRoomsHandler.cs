using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RoseHotel.Application.Abstractions;
using RoseHotel.Application.DTO;
using RoseHotel.Domain.Repositories;

namespace RoseHotel.Application.Queries.Handlers
{
    internal sealed class BrowserFreeRoomsHandler : IQueryHandler<BrowserReservationCheckIn, IReadOnlyList<RoomDto>>
    {

        private readonly IReservationRepository _reservationRepository;
        private readonly IClock _clock;

        public BrowserFreeRoomsHandler(IReservationRepository reservationRepository)
        {
            _reservationRepository = reservationRepository;
            
        }

        public async Task<IReadOnlyList<RoomDto>> HandleAsync(BrowserReservationCheckIn query)
        {

            var rooms = await _reservationRepository.BrowserAsyncFreeRooms(query.CheckIn, query.CheckOut);

            return rooms.Select(x => x.AsDto()).ToList();
        }
    }
}
