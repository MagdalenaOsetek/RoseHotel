using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RoseHotel.Domain.Entities;

namespace RoseHotel.Domain.Repositories
{
    public interface IRoomTypeRepository
    {
        Task<RoomType> GetAsync(Guid roomTypeId);
        Task<bool> ExistAsync( string type, decimal price, int capacity);
        Task<IReadOnlyCollection<RoomType>> BrowserAsync();
        Task AddAsync(RoomType roomType);
        Task UpdateAsync(RoomType roomType);
        Task DeleteAsync(RoomType roomType);
    }
}
