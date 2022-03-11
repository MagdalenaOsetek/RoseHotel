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
    class ChooseDateToBasketHandler : ICommandHandler<ChooseDateToBasket>
    {
        private readonly IBasketRepository _basketRepository;
        private readonly IClock _clock;

        public ChooseDateToBasketHandler(IBasketRepository basketRepository, IClock clock)
        {
            _basketRepository = basketRepository;
            _clock = clock;
        }
        public async Task HandleAsync(ChooseDateToBasket command)
        {

            var (checkIn, checkOut,roomsCapacity) = command;

            if (checkIn > checkOut || checkIn < _clock.GetCurrentTime())
            {
                throw new InvalidCheckInCheckOutException(checkIn, checkOut);
            }

            var basket = new Basket(command.BasketId,checkIn, checkOut, roomsCapacity.Select(x => (Capacity)x).ToList(),_clock.GetCurrentTime());

            await _basketRepository.UpdateAsync(basket);
        }
    }
}
