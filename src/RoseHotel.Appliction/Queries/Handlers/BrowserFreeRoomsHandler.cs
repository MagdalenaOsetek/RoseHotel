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
    internal sealed class BrowserFreeRoomsHandler : IQueryHandler<BrowserReservationCheckIn, IReadOnlyList<RoomDto>>
    {

        private readonly IReservationRepository _reservationRepository;

        public BrowserFreeRoomsHandler(IReservationRepository reservationRepository)
        {
            _reservationRepository = reservationRepository;
        }

        public async Task<IReadOnlyList<RoomDto>> HandleAsync(BrowserReservationCheckIn query)
        {
            var rooms = await _reservationRepository.BrowserAsyncFreeRooms(query.CheckIn, query.CheckIn, query.RoomsCapacity);


            return rooms.Select(x => x.AsDto()).ToList();
        }
    }
}
