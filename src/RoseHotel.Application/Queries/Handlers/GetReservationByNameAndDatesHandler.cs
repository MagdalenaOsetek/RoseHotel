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
    internal sealed class GetReservationByNameAndDatesHandler : IQueryHandler<GetReservationByNameAndDates, ReservationDto>
    {
        private readonly IReservationRepository _reservationRepository;

        public GetReservationByNameAndDatesHandler(IReservationRepository reservationRepository)
        {
            _reservationRepository = reservationRepository;
        }
        public async Task<ReservationDto> HandleAsync(GetReservationByNameAndDates query)
        {
           var reservation = await _reservationRepository.GetAsync(query.Name, query.Surname, query.CheckIn, query.CheckOut);

            return reservation.AsDto();

        }
    }
}
