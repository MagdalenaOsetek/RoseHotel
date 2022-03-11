using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RoseHotel.Application.Abstractions;
using RoseHotel.Application.DTO;
using RoseHotel.Application.Exceptions;
using RoseHotel.Domain.Repositories;

namespace RoseHotel.Application.Queries.Handlers
{
    internal sealed class BrowserUserReservationsHandler : IQueryHandler<BrowserUserReservations, IReadOnlyCollection<ReservationDto>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IReservationRepository _reservationRepository;

        public BrowserUserReservationsHandler(IUserRepository userRepository, IReservationRepository reservationRepository)
        {
            _userRepository = userRepository;
            _reservationRepository = reservationRepository;

        }
       
        public async Task<IReadOnlyCollection<ReservationDto>> HandleAsync(BrowserUserReservations query)
        {
            var user = await _userRepository.GetAsync(query.UserId);

            if (user is null)
            {
                throw new UserNotFoundException(query.UserId);
            }

            var reservations = await _reservationRepository.BrowserAsyncByGuest(user.GuestId);

            return  reservations.Select(x => x.AsDto()).ToList();


        }
    }
}
