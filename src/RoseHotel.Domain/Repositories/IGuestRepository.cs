using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RoseHotel.Domain.Entities;

namespace RoseHotel.Domain.Repositories
{
    public interface IGuestRepository
    {
        Task<Guest> GetAsync(Guid guestId);
        Task<Guest> GetAsync(string email);
        Task<Guest> GetAsync(string name, string surname);
        Task<Guest> GetAsync(string name, string surname, string natinality, string number, string email, string adress, string city, string country, string code);
        Task<IReadOnlyCollection<Guest>> BrowserAsync();
        Task AddAsync(Guest guest);
        Task UpdateAsync(Guest guest);
        Task DeleteAsync(Guest guest);



    }
}
