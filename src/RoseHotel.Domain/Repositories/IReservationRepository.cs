﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RoseHotel.Domain.Entities;

namespace RoseHotel.Domain.Repositories
{
    public interface IReservationRepository
    {
        Task<Reservation> GetAsync(Guid ReservationId);
       // Task<Reservation> GetAsync(string name, string surname, DateTime checkIn, DateTime checkOut);

        Task<IReadOnlyCollection<Reservation>> BrowserAsyncByCheckInDate(DateTime checkIn);
        Task<IReadOnlyCollection<Reservation>> BrowserAsyncByCheckOutDate(DateTime checkOut);
        Task<IReadOnlyCollection<Reservation>> BrowserAsyncByCheckInAndCheckOutDate(DateTime checkIn, DateTime checkOut);
        Task<IReadOnlyCollection<Reservation>> BrowserAsyncByGuestName(string name, string surname);
        Task<IReadOnlyCollection<Reservation>> BrowserAsyncByUser(Guid GuestId);
        Task<IReadOnlyCollection<Room>> BrowserAsyncFreeRooms(DateTime checkIn, DateTime checkOut, ICollection<Room> rooms);

        Task AddAsync(Reservation reservation);
        Task UpdateAsync(Reservation reservation);
        Task DeleteAsync(Reservation reservation);

    }
}