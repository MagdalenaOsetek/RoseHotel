using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RoseHotel.Domain.Entities;

namespace RoseHotel.Application.DTO
{
    public static class Extensions
    {

        public static RoomDto AsDto(this Room room)
            => new RoomDto()
            {
                RoomId = room.RoomId,
                Number = room.Number

            };


        public static RoomTypeDto AsDto(this RoomType roomtype)
            => new RoomTypeDto()
            {
                RoomTypeId = roomtype.RoomTypeId,
                Type = roomtype.Type,
                Capacity = roomtype.Capacity,
                Price = roomtype.Price

            };

        


        public static GuestDto AsDto(this Guest guest)
            => new GuestDto()
            {
                Name = guest.Name,
                Surname = guest.Surname,
                Email = guest.Email,
                PhoneNumber = guest.PhoneNumber
            };

        public static UserDto AsDto(this User user)
            => new UserDto()
            {
                UserId = user.UserId,
                Email = user.Email,
                Token = user.Token
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

        public static BasketDto AsDto(this Basket basket)
            => new BasketDto()
            {
                BasketId=basket.BasketId,
                CheckIn = basket.CheckIn,
                CheckOut= basket.CheckOut,
                RoomsCapacity= basket.RoomsCapacity,
                RoomsTypes = basket.RoomsTypes,
                Name = basket.Name,
                Surname = basket.Surname,
                CreatedAt = basket.CreatedAt,
                Email = basket.Email,
                PhoneNumber = basket.PhoneNumber,
                Adress = basket.Adress

            };

    }
}
