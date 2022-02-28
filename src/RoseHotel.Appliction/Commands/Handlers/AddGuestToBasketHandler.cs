using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RoseHotel.Appliction.Abstractions;
using RoseHotel.Domain.Repositories;

namespace RoseHotel.Appliction.Commands.Handlers
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
            var (basketId,name, surname, natinality, number, email, adress, city, country, code) = command;
            var basket = await _basketRepository.GetAsync(basketId);
            basket.AddGuest(name, surname, natinality, number, email, adress, city, country, code);
            await _basketRepository.UpdateAsync(basket);
        }
    }
}
