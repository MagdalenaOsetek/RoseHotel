using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RoseHotel.Domain.Entities;
using RoseHotel.Infrastructure.DAL.Configurations;

namespace RoseHotel.Infrastructure.DAL.Repositories
{
    class ReservationRepository : IReservationRepository
    {
        private readonly RoseHotelDbContext _context;
        private readonly DbSet<Reservation> _resrevations;
        private readonly DbSet<Room> _rooms;

        public ReservationRepository(RoseHotelDbContext context)
        {
            _context = context;
            _resrevations = context.Reservations;
            _rooms = context.Rooms;
        }

        public async Task AddRservation(Reservation reservation)
        {
            await _resrevations.AddAsync(reservation);
            await _context.SaveChangesAsync();

        }

        public async Task<IReadOnlyCollection<Reservation>> BrowserAsyncByCheckInAndCheckOutDate(DateTime checkIn, DateTime checkOut)
        {
            return await _resrevations.Include(x => x.Rooms).Where(x => x.CheckIn.Equals(checkIn) && x.CheckOut.Equals(checkOut)).ToListAsync();
        }

        public async Task<IReadOnlyCollection<Reservation>> BrowserAsyncByCheckInDate(DateTime checkIn)
        {
            return await _resrevations.Include(x => x.Rooms).Where(x => x.CheckIn.Equals(checkIn)).ToListAsync();
        }

        public async Task<IReadOnlyCollection<Reservation>> BrowserAsyncByCheckOutDate(DateTime checkOut)
        {
            return await _resrevations.Include(x => x.Rooms).Where(x => x.CheckOut.Equals(checkOut)).ToListAsync();
        }

        public async Task<IReadOnlyCollection<Reservation>> BrowserAsyncByGuestName(string name, string surname)
        {
            return await _resrevations.Include(x => x.Rooms).Where(x => x.Guest.Name.Equals(name) && x.Guest.Surname.Equals(surname)).ToListAsync();
        }

        public Task<IReadOnlyCollection<Room>> BrowserAsyncFreeRooms(DateTime checkIn, DateTime checkOut, ICollection<Room> rooms)
        {
            throw new NotImplementedException();
        }

        public Task DeleteRservation(Reservation reservation)
        {
            throw new NotImplementedException();
        }

        public Task<Reservation> GetAsync(string name, string surname, DateTime checkIn, DateTime checkOut)
        {
            throw new NotImplementedException();
        }

        public Task<Reservation> GetAync(Guid ReservationId)
        {
            throw new NotImplementedException();
        }

        public Task UpdateRservation(Reservation reservation)
        {
            throw new NotImplementedException();
        }
    }
}
