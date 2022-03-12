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
        private readonly DbSet<RoomType> _roomsTypes;

        public ReservationRepository(RoseHotelDbContext context)
        {
            _context = context;
            _resrevations = context.Reservations;
            _rooms = context.Rooms;
            _roomsTypes = context.RoomsTypes;
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

        public async Task<IReadOnlyCollection<RoomType>> BrowserAsyncFreeRooms(DateTime checkIn, DateTime checkOut, int capacity)
        {


            var taken = await _resrevations.Include(x => x.Rooms)
                .Where(x => !((x.CheckIn < checkIn || x.CheckOut <= checkIn) || (x.CheckIn >= checkOut || x.CheckOut > checkOut)))
                .Select(x => x.Rooms)
                .SelectMany(x => x)
                .Include(x => x.RoomType)
                .Where(x=> x.RoomType.Capacity >= capacity)
                .ToListAsync();

            var lol = await _rooms.ToListAsync();
            var free = await _rooms.Where(x => !taken.Contains(x))
                .Include(x => x.RoomType)
                .Select(x => x.RoomType)
                .Distinct()
                .ToListAsync();
         

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



        public async Task<Room> GetFreeRoomAsync(Guid roomTypeId, DateTime checkIn, DateTime checkOut)
        {

            var taken = await _resrevations.Include(x => x.Rooms)
                .Where(x => !((x.CheckIn < checkIn || x.CheckOut <= checkIn) || (x.CheckIn >= checkOut || x.CheckOut > checkOut)))
                .Select(x => x.Rooms)
                .SelectMany(x => x)
                .ToListAsync();

            var free = await _rooms.Where(x => !taken.Contains(x) && x.RoomTypeId == roomTypeId).Include(x => x.RoomType)
                .FirstAsync();

            return free;
        }


    }
}
