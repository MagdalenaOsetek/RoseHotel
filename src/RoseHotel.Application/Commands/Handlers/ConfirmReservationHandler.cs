using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RoseHotel.Application.Abstractions;
using RoseHotel.Domain.Entities;
using RoseHotel.Domain.Repositories;

namespace RoseHotel.Application.Commands.Handlers
{
    public class ConfirmReservationHandler : ICommandHandler<ConfirmReservation>
    {
        private readonly IBasketRepository _basketRepository;
        private readonly IReservationRepository _reservationRepository;
        private readonly IGuestRepository _guestRepository;
        private readonly IRoomRepository _roomRepository;
        private readonly IClock _clock;
    

        public ConfirmReservationHandler(IBasketRepository basketRepository, IReservationRepository reservationRepository, IGuestRepository guestRepository,IRoomRepository roomRepository, IClock clock )
        {
            _basketRepository = basketRepository;
            _reservationRepository = reservationRepository;
            _guestRepository = guestRepository;
            _roomRepository = roomRepository;
            _clock = clock;
        }
        public async Task HandleAsync(ConfirmReservation command)
        {            
            var basket = await _basketRepository.GetAsync(command.BasketId);

            Guest guest = await _guestRepository.GetAsync(basket.Name, basket.Surname, basket.PhoneNumber, basket.Email, basket.Adress.Street, basket.Adress.City, basket.Adress.Country, basket.Adress.ZipCode);
                
            
            if(guest is null)
            {
                 guest = new Guest(command.GuestId,basket.Name, basket.Surname,_clock.GetCurrentTime(), basket.Email,basket.PhoneNumber, basket.Adress);
                await  _guestRepository.AddAsync(guest);
            }

            var rooms = new List<Room>();
            foreach ( var x in basket.Rooms)
            {
               var r =  await _roomRepository.GetAsync(x);
                rooms.Add(r);
            }
            

            var reservation = new Reservation(command.ReservationId, rooms, guest, basket.CheckIn, basket.CheckOut, _clock.GetCurrentTime());

            await _reservationRepository.AddAsync(reservation);

            await _basketRepository.DeleteAsync(basket.BasketId);
                
        }
    }
}
