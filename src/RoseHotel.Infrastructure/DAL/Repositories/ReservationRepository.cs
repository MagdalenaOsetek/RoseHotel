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
            return await _resrevations.Include(x => x.Rooms).Where(x => x.CheckIn == checkIn && x.CheckOut == checkOut).ToListAsync();
        }

        public async Task<IReadOnlyCollection<Reservation>> BrowserAsyncByCheckInDate(DateTime checkIn)
        {
            return await _resrevations.Include(x => x.Rooms).Where(x => x.CheckIn ==checkIn).ToListAsync();
        }

        public  async Task<IReadOnlyCollection<Reservation>> BrowserAsyncByCheckOutDate(DateTime checkOut)
        {
            return await _resrevations.Include(x => x.Rooms).Where(x =>  x.CheckOut == checkOut).ToListAsync();
        }

        public async Task<IReadOnlyCollection<Reservation>> BrowserAsyncByGuestName(string name, string surname)
        {
            return await _resrevations.Include(x=>x.Rooms).Where(x => x.Guest.Name == name && x.Guest.Surname == surname).ToListAsync();
        }

        public async Task<IReadOnlyCollection<Reservation>> BrowserAsyncByGuest(Guid guestId)
        {
           return await _resrevations.Include(x => x.Rooms).Where(x => x.GuestId == guestId).ToListAsync();
        }

        public async Task<IReadOnlyCollection<Room>> BrowserAsyncFreeRooms(DateTime checkIn, DateTime checkOut, int capacity)
        {


            var taken = await _resrevations.Include(x => x.Rooms)
                .Where(x => !((x.CheckIn < checkIn || x.CheckOut <= checkIn) || (x.CheckIn >= checkOut || x.CheckOut > checkOut)))
                .Select(x => x.Rooms)
                .SelectMany(x => x)
                .Where(x=> x.Capacity >= capacity)
                .ToListAsync();
            var free = await _rooms.Where(x => !taken.Contains(x)).ToListAsync();

            return free;

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

        public Task<Reservation> GetAsync(Guid reservationId) => _resrevations.SingleOrDefaultAsync(x => x.ReservationId == reservationId);



        public async Task UpdateAsync(Reservation reservation)
        {

            _resrevations.Update(reservation);
            await _context.SaveChangesAsync();
        }




        public async Task<bool> CheckIfFreeAsync(Guid roomId, DateTime checkIn, DateTime checkOut)
        {


            var taken = await _resrevations.Include(x => x.Rooms)
                .Where(x => !((x.CheckIn < checkIn || x.CheckOut <= checkIn) || (x.CheckIn >= checkOut || x.CheckOut > checkOut)))
                .Select(x => x.Rooms)
                .SelectMany(x => x)
                .Select(x => x.RoomId)
                .ToListAsync(); 
            
            if (!taken.Contains(roomId))
            {
                return true;
            }

            return false;
        }



        public async Task<Room> GetFreeRoomAsync(int capacity, string roomType, DateTime checkIn, DateTime checkOut)
        {


            var taken = await _resrevations.Include(x => x.Rooms)
                .Where(x => !((x.CheckIn < checkIn || x.CheckOut <= checkIn) || (x.CheckIn >= checkOut || x.CheckOut > checkOut)))
                .Select(x => x.Rooms)
                .SelectMany(x => x)
                .Select(x => x.RoomId)
                .ToListAsync();

            if (!taken.Contains(roomId))
            {
                return true;
            }

            return false;
        }


    }
}
