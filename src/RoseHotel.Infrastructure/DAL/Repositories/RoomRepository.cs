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
    internal sealed class RoomRepository : IRoomRepository
    {
        private  RoseHotelDbContext _context;
        private  DbSet<Room> _rooms;

        public RoomRepository(RoseHotelDbContext context)
        {
            _context = context;
            _rooms = context.Rooms;
        }

        public async Task AddAsync(Room room)
        {
            await _rooms.AddAsync(room);
            await _context.SaveChangesAsync();
        }

        public async Task<IReadOnlyCollection<Room>> BrowserAsync(string roomType)
        {
           return  await _rooms.Where(x => x.Type == roomType).ToListAsync();
          
        }

        public async Task<IReadOnlyCollection<Room>> BrowserAsync(int capacity)
        {
            return await _rooms.Where(x => x.Capacity == capacity).ToListAsync();
        }

        public async Task DeleteAsync(Room room)
        {
            _rooms.Remove(room);
            await _context.SaveChangesAsync();
        }

        public Task<bool> ExistsAsync(Guid roomId) => _rooms.AnyAsync(x => x.RoomId == roomId);


        public  Task<Room> GetAsync(Guid roomId) =>  _rooms.SingleOrDefaultAsync(x => x.RoomId == roomId);


        public  Task<Room> GetAsync(int number) =>  _rooms.SingleOrDefaultAsync(x => x.Number == number);


        public async Task UpdateAsync(Room room)
        {
            _rooms.Update(room);
            await _context.SaveChangesAsync();
        }
    }
}
