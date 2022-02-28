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
    internal sealed class UserRepository : IUserRepository
    {
        private  RoseHotelDbContext _context;
        private  DbSet<User> _users;

        public UserRepository(RoseHotelDbContext context)
        {    
            _context = context;
            _users = context.Users;
        }

        public async Task AddAsync(User user)
        {
            await _users.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        public async Task<IReadOnlyCollection<User>> BrowserAsync()
        {
           return await _users.ToListAsync();
        }

        public async Task DeleteAsync(User user)
        {
             _users.Remove(user);
            await _context.SaveChangesAsync();
        }

        public Task<bool> ExistsAsync(Guid userId)
            => _users.AnyAsync(x => x.UserId.Equals(userId));

        public Task<User> GetAsync(Guid userId) => _users.SingleOrDefaultAsync(x => x.UserId.Equals(userId));


        public Task<User> GetAsync(string email) => _users.SingleOrDefaultAsync(x => x.Email.Equals(email));


        public async Task UpdateAsync(User user)
        {
             _users.Update(user);
            await _context.SaveChangesAsync();
        }
    }
}
