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
    internal sealed class GetReservationHandler : IQueryHandler<GetReservation, ReservationDto>
    {
        private readonly IReservationRepository _reservationRepository;

        public GetReservationHandler (IReservationRepository reservationRepository)
        {
            _reservationRepository = reservationRepository;
        }
        public async Task<ReservationDto> HandleAsync(GetReservation query)
        {
            var reservation = await _reservationRepository.GetAync(query.ReservationId);

            return reservation.AsDto();

        }
    }
}
