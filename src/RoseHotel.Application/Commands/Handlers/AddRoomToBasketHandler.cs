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
        private readonly IRoomTypeRepository _roomTypeRepository;


        public AddRoomToBasketHandler (IBasketRepository basketRepository,IRoomTypeRepository roomTypeRepository)
        {
            _basketRepository = basketRepository;
            _roomTypeRepository = roomTypeRepository;
          
        }
        public async Task HandleAsync(AddRoomToBasket command)
        {
            var (basketId, roomType) = command;

            var basket = await _basketRepository.GetAsync(basketId);
            if (basket is null)
            {
                throw new BasketNotFoundException(basketId);
            }

            if (basket.RoomsCapacity.Count == basket.RoomsTypes.Count)
            {
                throw new AllRoomsAlreadyAddedToBasketException(basketId);
            }

            var room = await _roomTypeRepository.GetAsync(roomType);

            if (room == null)
            {
                throw new RoomTypeNotFoundException(roomType);
            }

        

            basket.AddRoom(roomType);
            await _basketRepository.UpdateAsync(basket);
        }
    }
}
