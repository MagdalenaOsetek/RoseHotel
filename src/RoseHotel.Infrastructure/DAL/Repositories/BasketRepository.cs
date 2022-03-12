using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JsonNet.ContractResolvers;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using RoseHotel.Application.DTO;
using RoseHotel.Domain.Entities;
using RoseHotel.Domain.Repositories;

namespace RoseHotel.Infrastructure.DAL.Repositories
{
    internal sealed class BasketRepository : IBasketRepository
    {

        private readonly IDistributedCache _redisCache;

        public BasketRepository(IDistributedCache cache)
        {
            _redisCache = cache ?? throw new ArgumentNullException(nameof(cache));
        }

        public async Task<Basket> GetAsync(Guid basketId)
        {
            var basket = await _redisCache.GetStringAsync(basketId.ToString());

            if (String.IsNullOrEmpty(basket))
                return null;

            var settings = new JsonSerializerSettings
            {
                ContractResolver = new PrivateSetterContractResolver()
            };

            return JsonConvert.DeserializeObject<Basket>(basket, settings);

            
            
        }

        public async Task UpdateAsync(Basket basket)
        {

            var options = new DistributedCacheEntryOptions()
                .SetAbsoluteExpiration(DateTime.Now.AddHours(1));
               
            await _redisCache.SetStringAsync(basket.BasketId.ToString(), JsonConvert.SerializeObject(basket), options   );

        }

        public async Task DeleteAsync(Guid basketId)
        {
            await _redisCache.RemoveAsync(basketId.ToString());
        }
    }
}
