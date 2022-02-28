﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RoseHotel.Appliction.Abstractions;
using RoseHotel.Appliction.Exceptions;
using RoseHotel.Domain.Repositories;

namespace RoseHotel.Appliction.Commands.Handlers
{
    public class CancelReservationHandler : ICommandHandler<CancelReservation>
    {
        private readonly IReservationRepository _reservationRepository;

        public CancelReservationHandler(IReservationRepository reservationRepository)
        {
            _reservationRepository = reservationRepository;
        }
        public async Task HandleAsync(CancelReservation command)
        {
            var reservation = await _reservationRepository.GetAsync(command.ReservationId);

            if( reservation is null)
            {
                throw new ReservationNotFoundException(command.ReservationId);
            }

            await _reservationRepository.DeleteAsync(reservation);
        }
    }
}
