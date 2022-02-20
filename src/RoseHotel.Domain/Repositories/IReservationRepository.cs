using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RoseHotel.Domain.Entities;

namespace RoseHotel.Infrastructure.DAL.Configurations
{
    public interface IReservationRepository
    {
        Task<Reservation> GetAync(Guid ReservationId);
        Task<Reservation> GetAsync(string name, string surname, DateTime checkIn, DateTime checkOut);
        Task<IReadOnlyCollection<Reservation>> BrowserAsyncByCheckInDate(DateTime checkIn);
        Task<IReadOnlyCollection<Reservation>> BrowserAsyncByCheckOutDate(DateTime checkOut);
        Task<IReadOnlyCollection<Reservation>> BrowserAsyncByCheckInAndCheckOutDate(DateTime checkIn, DateTime checkOut);
        Task<IReadOnlyCollection<Reservation>> BrowserAsyncByGuestName(string name, string surname);
        Task<IReadOnlyCollection<Room>> BrowserAsyncFreeRooms(DateTime checkIn, DateTime checkOut, ICollection<Room> rooms);

        Task AddRservation(Reservation reservation);
        Task UpdateRservation(Reservation reservation);
        Task DeleteRservation(Reservation reservation);
    }
}
