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
    internal sealed class DeleteRoomFromBasketHandler : ICommandHandler<DeleteRoomFromBasket>
    {
        private readonly IBasketRepository _basketRepository;

        public DeleteRoomFromBasketHandler(IBasketRepository basketRepository)
        {
            _basketRepository = basketRepository;
        }


        public async Task HandleAsync(DeleteRoomFromBasket command)
        {
            var (basketId, roomTypeId) = command;
            var basket = await _basketRepository.GetAsync(basketId);

            if(basket == null)
            {
                throw new BasketNotFoundException(basketId);
            }

            basket.RoomsTypes.Remove(basketId);

            await _basketRepository.UpdateAsync(basket);
        }
    }
}
