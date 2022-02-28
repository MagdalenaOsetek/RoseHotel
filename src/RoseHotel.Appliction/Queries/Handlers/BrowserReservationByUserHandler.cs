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
    internal sealed class BrowserReservationByUserHandler : IQueryHandler<BrowserReservationByUser, IReadOnlyCollection<ReservationDto>>
    {
        private readonly IReservationRepository _reservationRepository;

        public BrowserReservationByUserHandler (IReservationRepository reservationRepository)
        {
            _reservationRepository = reservationRepository;

        }
        public async Task<IReadOnlyCollection<ReservationDto>> HandleAsync(BrowserReservationByUser query)
        {
            var reservation = await _reservationRepository.BrowserAsyncByUser(query.UserId);

            return reservation.Select(x => x.AsDto()).ToList();
        }
    }
}
