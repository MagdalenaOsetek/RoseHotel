using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RoseHotel.Domain.Entities;

namespace RoseHotel.Domain.Repositories
{
    public interface IRoomRepository
    {

        Task<Room> GetAsync(Guid roomId);
        Task<Room> GetAsync(int number);
        Task<IReadOnlyCollection<Room>> BrowserAsync(string roomType);
        Task<IReadOnlyCollection<Room>> BrowserAsync(int capacity);

        Task AddAsync(Room room);
        Task UpdateAsync(Room room);
        Task DeleteAsync(Room room);
    }
}
