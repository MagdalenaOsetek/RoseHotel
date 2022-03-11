using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RoseHotel.Application.Abstractions;
using RoseHotel.Application.DTO;
using RoseHotel.Domain.Repositories;

namespace RoseHotel.Application.Queries.Handlers
{
    internal sealed class GetBasketHandler : IQueryHandler<GetBasket, BasketDto>
    {
        private readonly IBasketRepository _basketReposiotry;

        public GetBasketHandler(IBasketRepository basketReposiotry)
        {
            _basketReposiotry = basketReposiotry;
        }
        public async Task<BasketDto> HandleAsync(GetBasket query)
        {
            var basket = await _basketReposiotry.GetAsync(query.BasketId);

            return basket.AsDto();
        }
    }
}
