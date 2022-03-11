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
    public class AddRoomToBasketHandler : ICommandHandler<AddRoomToBasket>
    {
        private readonly IBasketRepository _basketRepository;
        private readonly IRoomRepository _roomRepository;
        private readonly IReservationRepository _reservationRepository;

        public AddRoomToBasketHandler (IBasketRepository basketRepository,IRoomRepository roomRepository, IReservationRepository reservationRepository)
        {
            _basketRepository = basketRepository;
            _roomRepository = roomRepository;
            _reservationRepository = reservationRepository;
        }
        public async Task HandleAsync(AddRoomToBasket command)
        {
            var (basketId, capacity, roomType) = command;

            var basket = await _basketRepository.GetAsync(basketId);
            if (basket is null)
            {
                throw new BasketNotFoundException(basketId);
            }

            if (basket.RoomsCapacity.Count == basket.Rooms.Count)
            {
                throw new AllRoomsAlreadyAddedToBasketException(basketId);
            }

        

            basket.AddRoom(capacity, roomType);
            await _basketRepository.UpdateAsync(basket);
        }
    }
}
