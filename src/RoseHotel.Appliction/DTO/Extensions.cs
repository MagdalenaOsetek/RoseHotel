using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RoseHotel.Domain.Entities;

namespace RoseHotel.Appliction.DTO
{
    public static class Extensions
    {

        public static RoomDto AsDto(this Room room)
            => new RoomDto()
            {
                RoomId = room.RoomId,
                Type = room.Type,
                Capacity = room.Capacity,
                Price = room.Price

            };

        public static GuestDto AsDto(this Guest guest)
            => new GuestDto()
            {
                Name = guest.Name,
                Surname = guest.Surname,
                Email = guest.Email,
                PhoneNumber = guest.PhoneNumber
            };

        public static ReservationDto AsDto(this Reservation reservation)
            => new ReservationDto()
            {
                ReservationId = reservation.ReservationId,
                CheckIn = reservation.CheckIn,
                CheckOut = reservation.CheckOut,
                ToPay =  reservation.ToPay,
                Paid = reservation.Paid,
                Rooms = reservation.Rooms.Select(x => x.AsDto()).ToList(),
                Guest = reservation.Guest.AsDto()

            };

    }
}
