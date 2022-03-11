using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RoseHotel.Domain.Entities;


namespace RoseHotel.Domain.Repositories
{
    public interface IBasketRepository
    {
        Task<Basket> GetAsync(Guid basketId);
        Task UpdateAsync(Basket basket);
        Task DeleteAsync(Guid basketId);
    }
}
