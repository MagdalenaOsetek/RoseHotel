using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RoseHotel.Application.Abstractions;
using RoseHotel.Application.Exceptions;
using RoseHotel.Domain.Entities;
using RoseHotel.Domain.Repositories;
using RoseHotel.Domain.ValueObjects;

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

            if(basket == null)
            {
                throw new BasketNotFoundException(command.BasketId);
            }

            if (basket.RoomsTypes.Count != basket.RoomsCapacity.Count)
            {
                throw new RoomNotAddedToBasketException(command.BasketId);
            }

            if(basket.Name == null || basket.Surname == null || basket.Email ==null || basket.PhoneNumber == null || basket.Adress == null)
            {
                throw new GuestNotAddedToBasketException(command.BasketId);
            }

            Guest guest = await _guestRepository.GetAsync(basket.Name, basket.Surname, basket.PhoneNumber, basket.Email, basket.Adress.Street, basket.Adress.City, basket.Adress.Country, basket.Adress.ZipCode);
                
            
            if(guest is null)
            {
                
               guest = new Guest(command.GuestId,basket.Name, basket.Surname,_clock.GetCurrentTime(), basket.Email,basket.PhoneNumber, basket.Adress);
               
            }

            var rooms = new List<Room>();
            foreach ( var x in basket.RoomsTypes)
            {
              
                var roomFree = await _reservationRepository.GetFreeRoomAsync(x, basket.CheckIn, basket.CheckOut);
                
                if(roomFree == null)
                {
                    throw new RoomIsTakenException();
                }
                rooms.Add(roomFree);
                             
            }
            

            var reservation = new Reservation(command.ReservationId, rooms, guest, basket.CheckIn, basket.CheckOut, _clock.GetCurrentTime());
            

            await _reservationRepository.AddAsync(reservation);

            await _basketRepository.DeleteAsync(basket.BasketId);
                
        }
    }
}
