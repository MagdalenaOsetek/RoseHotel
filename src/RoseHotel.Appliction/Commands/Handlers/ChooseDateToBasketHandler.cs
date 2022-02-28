using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RoseHotel.Appliction.Abstractions;
using RoseHotel.Domain.Entities;
using RoseHotel.Domain.Repositories;
using RoseHotel.Domain.ValueObjects;

namespace RoseHotel.Appliction.Commands.Handlers
{
    class ChooseDateToBasketHandler : ICommandHandler<ChooseDateToBasket>
    {
        private readonly IBasketRepository _basketRepository;

        public ChooseDateToBasketHandler(IBasketRepository basketRepository)
        {
            _basketRepository = basketRepository;

        }
        public async Task HandleAsync(ChooseDateToBasket command)
        {

            var (checkIn, checkOut,roomsCapacity) = command;
       
            var basket = new Basket(command.BasketId,checkIn, checkOut, roomsCapacity.Select(x => (Capacity)x).ToList());

            await _basketRepository.UpdateAsync(basket);
        }
    }
}
