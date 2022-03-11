using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using RoseHotel.Domain.Entities;
using RoseHotel.Domain.Repositories;



namespace RoseHotel.Infrastructure.DAL.Repositories
{
    internal sealed class UserRepository : IUserRepository
    {
        private readonly RoseHotelDbContext _context;
        private readonly DbSet<User> _users;
        private readonly AppSettings _appSettings;

        public UserRepository(RoseHotelDbContext context, IOptions<AppSettings> appSettings)
        {    
            _context = context;
            _users = context.Users;
            _appSettings = appSettings.Value;
        }

        public async Task AddAsync(User user)
        {
            await _users.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        public async Task<User> AuthenticateAsync(string email, string password)
        {
            var user = await _users.SingleOrDefaultAsync(x => x.Email == email && x.Password == password);

            if (user == null)
            {
                return null;
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[] {
                    new Claim(ClaimTypes.Name,user.Email),
                    new Claim(ClaimTypes.Role,user.Role)
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials
                                (new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            user.Token = tokenHandler.WriteToken(token);

            return user;
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

        public Task<bool> ExistsAsync(string email)
            => _users.AnyAsync(x => x.Email == email);


        public Task<User> GetAsync(Guid userId) => _users.SingleOrDefaultAsync(x => x.UserId == userId);

        //public Task<User> GetAsync(string email, string password) => _users.SingleOrDefaultAsync(x => x.Email == email && x.Password == password);

        public Task<User> GetAsync(string email, string password) => _users.SingleOrDefaultAsync(x => x.Email == email && x.Password == password);
   


        public async Task UpdateAsync(User user)
        {
             _users.Update(user);
            await _context.SaveChangesAsync();
        }
    }
}
