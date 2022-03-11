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
    public class AddGuestToBasketHandler : ICommandHandler<AddGuestToBasket>
    {
        private readonly IBasketRepository _basketRepository;

        public AddGuestToBasketHandler(IBasketRepository basketRepository)
        {
            _basketRepository = basketRepository;
        }
        public async Task HandleAsync(AddGuestToBasket command)
        {
            var (basketId,name, surname,  number, email, adress, city, country, code) = command;
            var basket = await _basketRepository.GetAsync(basketId);

            if(basket == null)
            {
                throw new BasketNotFoundException(basketId);
            }

            basket.AddGuest(name, surname, number, email, adress, city, country, code);
            await _basketRepository.UpdateAsync(basket);
        }
    }
}
