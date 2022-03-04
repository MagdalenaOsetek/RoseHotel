using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RoseHotel.Domain.Entities;
using RoseHotel.Domain.Repositories;






namespace RoseHotel.Infrastructure.DAL.Repositories
{
    internal sealed class ReservationRepository : IReservationRepository
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

        public async Task AddAsync(Reservation reservation)
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

        public  async Task<IReadOnlyCollection<Reservation>> BrowserAsyncByCheckOutDate(DateTime checkOut)
        {
            return await _resrevations.Include(x => x.Rooms).Where(x =>  x.CheckOut.Equals(checkOut)).ToListAsync();
        }

        public async Task<IReadOnlyCollection<Reservation>> BrowserAsyncByGuestName(string name, string surname)
        {
            return await _resrevations.Include(x=>x.Rooms).Where(x => x.Guest.Name.Equals(name) && x.Guest.Surname.Equals(surname)).ToListAsync();
        }

        public Task<IReadOnlyCollection<Reservation>> BrowserAsyncByUser(Guid GuestId)
        {
            throw new NotImplementedException();
        }

        public async Task<IReadOnlyCollection<Room>> BrowserAsyncFreeRooms(DateTime checkIn, DateTime checkOut)
        {

            var taken = await _resrevations.Include(x => x.Rooms).Where(x => x.CheckIn <= checkIn || x.CheckOut >= checkOut).Select(x => x.Rooms).SelectMany(x =>x).ToListAsync();
            return await _rooms.Where( x =>  taken.Contains(x)).ToListAsync();

        }

        public async Task DeleteAsync(Reservation reservation)
        {
            _resrevations.Remove(reservation);
            await _context.SaveChangesAsync();
        }


        public Task<Reservation> GetAsync(string name, string surname, DateTime checkIn, DateTime checkOut)
        {
            throw new NotImplementedException();
        }

        public Task<Reservation> GetAsync(Guid reservationId) => _resrevations.SingleOrDefaultAsync(x => x.ReservationId.Equals(reservationId));


        public async Task UpdateAsync(Reservation reservation)
        {

            _resrevations.Update(reservation);
            await _context.SaveChangesAsync();
        }


    }
}
