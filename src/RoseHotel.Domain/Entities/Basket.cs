using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RoseHotel.Domain.ValueObjects;

namespace RoseHotel.Domain.Entities
{
    public class Basket
    {
        public Guid BasketId { get; private set; }
        public DateTime CheckIn { get; private set; }
        public DateTime CheckOut { get; private set; }
        public List<Capacity>RoomsCapacity { get; private set; }
        public List<Guid> Rooms { get; private set; }
        public Guid UserId { get; private set; }
        public string Name { get; private set; }
        public string Surname { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public Email Email { get; private set; }
        public PhoneNumber PhoneNumber { get; private set; }
        public Adress Adress { get; private set; }

        public Basket(Guid basketId, DateTime checkIn, DateTime checkOut, List<Capacity> roomsCapacity, List<Guid> rooms, Guid userId, string name, string surname, DateTime createdAt, Email email, PhoneNumber phoneNumber, Adress adress) : this(basketId, checkIn, checkOut, roomsCapacity)
        {
            Rooms = rooms;
            UserId = userId;
            Name = name;
            Surname = surname;
            CreatedAt = createdAt;
            Email = email;
            PhoneNumber = phoneNumber;
            Adress = adress;
        }

        public Basket (Guid basketId, DateTime checkIn, DateTime checkOut, List<Capacity> roomsCapacity)
        {
            BasketId = basketId;
            CheckIn = checkIn;
            CheckOut = checkOut;
            RoomsCapacity = roomsCapacity;
        }

        public void AddRoom(Guid roomId)
        {
            Rooms.Add(roomId);
        }

        public void AddGuest(string name, string surname,  string number, string email, string adress, string city, string country, string code)
        {
            Name = name;
            Surname = surname;
            PhoneNumber = number;
            Email = email;
            Adress = new Adress(adress, city, country, code);
        }
    }
}
