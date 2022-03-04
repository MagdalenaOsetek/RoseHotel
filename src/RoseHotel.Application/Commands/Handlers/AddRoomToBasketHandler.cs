using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RoseHotel.Application.Abstractions;
using RoseHotel.Domain.Repositories;

namespace RoseHotel.Application.Commands.Handlers
{
    public class AddRoomToBasketHandler : ICommandHandler<AddRoomToBasket>
    {
        private readonly IBasketRepository _basketRepository;

        public AddRoomToBasketHandler (IBasketRepository basketRepository)
        {
            _basketRepository = basketRepository;
        }
        public async Task HandleAsync(AddRoomToBasket command)
        {
            var (basketId, roomId) = command;
            var basket = await _basketRepository.GetAsync(basketId);
            basket.AddRoom(roomId);
            await _basketRepository.UpdateAsync(basket);
        }
    }
}
