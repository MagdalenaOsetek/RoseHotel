using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RoseHotel.Domain.Entities;
using RoseHotel.Domain.Repositories;

namespace RoseHotel.Infrastructure.DAL.Repositories
{
    internal sealed class RoomTypeRepository : IRoomTypeRepository
    {
        private RoseHotelDbContext _context;
        private DbSet<RoomType> _roomsTypes;

        public RoomTypeRepository(RoseHotelDbContext context)
        {
            _context = context;
            _roomsTypes = context.RoomsTypes;
        }
        public async Task AddAsync(RoomType roomType)
        {
            await _roomsTypes.AddAsync(roomType);
            await _context.SaveChangesAsync();
        }

        public async Task<IReadOnlyCollection<RoomType>> BrowserAsync()
        {
            return await _roomsTypes.ToListAsync();
        }

        public async Task DeleteAsync(RoomType roomType)
        {
            _roomsTypes.Remove(roomType);
            await _context.SaveChangesAsync();
        }

        public Task<bool> ExistAsync(string type, decimal price, int capacity) => _roomsTypes
            .AnyAsync(x => x.Type == type && x.Price == price && x.Capacity == capacity);



        public Task<RoomType> GetAsync(Guid roomTypeId) => _roomsTypes.SingleOrDefaultAsync(x => x.RoomTypeId == roomTypeId);
     

        public async Task UpdateAsync(RoomType roomType)
        {
            _roomsTypes.Update(roomType);
            await _context.SaveChangesAsync();
        }
    }
}
