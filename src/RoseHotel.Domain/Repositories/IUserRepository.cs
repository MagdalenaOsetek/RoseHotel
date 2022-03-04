using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RoseHotel.Domain.Entities;

namespace RoseHotel.Domain.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetAsync(Guid userId);
        Task<User> GetAsync(string email,string password);
        Task<bool> ExistsAsync(Guid userId);
        Task<IReadOnlyCollection<User>> BrowserAsync();
        Task AddAsync(User user);
        Task UpdateAsync(User user);
        Task DeleteAsync(User user);
    }
}
