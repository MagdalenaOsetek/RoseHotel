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
    class GuestRepository : IGuestRepository
    {
        private RoseHotelDbContext _context;
        private DbSet<Guest> _guests;

        public GuestRepository (RoseHotelDbContext context)
        {
            _context = context;
            _guests = context.Guests;
        }



        public async Task AddAsync(Guest guest)
        {
            await _guests.AddAsync(guest);
            await _context.SaveChangesAsync();
        }

        public Task<IReadOnlyCollection<Guest>> BrowserAsync()
        {
            throw new NotImplementedException();
        }

        public async Task DeleteAsync(Guest guest)
        {
             _guests.Remove(guest);
            await _context.SaveChangesAsync();
        }

        public Task<Guest> GetAsync(string name, string surname, string number, string email, string street, string city, string country, string code)
            => _guests.SingleOrDefaultAsync(x => x.Name == name
            && x.Surname == surname
            && x.PhoneNumber == number
            && x.Email == email
            && x.Adress.Street == street
            && x.Adress.City == city
            && x.Adress.Country == country
            && x.Adress.ZipCode == code);


        public Task<Guest> GetAsync(Guid guestId) => _guests.SingleOrDefaultAsync(x => x.GuestId == guestId);



        public Task<Guest> GetAsync(string email)
        {
            throw new NotImplementedException();
        }

        public Task<Guest> GetAsync(string name, string surname)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(Guest guest)
        {
             _guests.Update(guest);
            await _context.SaveChangesAsync();
        }
    }
}
