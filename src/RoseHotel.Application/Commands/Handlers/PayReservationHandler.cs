using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RoseHotel.Application.Abstractions;
using RoseHotel.Application.Exceptions;
using RoseHotel.Domain.Repositories;

namespace RoseHotel.Application.Commands.Handlers
{
    public class PayReservationHandler : ICommandHandler<PayReservation>
    {
        private readonly IReservationRepository _reservationRepository;
        private readonly IGuestRepository _guestRepository;

        public PayReservationHandler(IReservationRepository reservationRepository, IGuestRepository guestRepository)
        {
            _reservationRepository = reservationRepository;
            _guestRepository = guestRepository;

        }
        public async Task HandleAsync(PayReservation command)
        {
            var (id, amount,cardNumber,  expirationDate,  cvv,  fullName) = command;
            var reservation = await _reservationRepository.GetAsync(id);

            if (reservation is null)
            {
                throw new ReservationNotFoundException(id);
            }
            if(reservation.Guest is null)
            {
                throw new GuestNotFoundException(reservation.Guest.GuestId);
            }

            reservation.Guest.AddCard(cardNumber, expirationDate, cvv, fullName);

            reservation.Pay(amount);

            await _guestRepository.UpdateAsync(reservation.Guest);
            await _reservationRepository.UpdateAsync(reservation);
        }
    }
}
