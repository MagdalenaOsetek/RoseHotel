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
        public List<RoomModel> Rooms { get; private set; } = new List<RoomModel>();
        public Guid UserId { get; private set; }
        public string Name { get; private set; }
        public string Surname { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public Email Email { get; private set; }
        public PhoneNumber PhoneNumber { get; private set; }
        public Adress Adress { get; private set; }

        public struct RoomModel
        {
            public Capacity capacity;
            public RoomType roomType;
        }
        public Basket()
        {

        }

        public Basket (Guid basketId, DateTime checkIn, DateTime checkOut, List<Capacity> roomsCapacity, DateTime createdAt)
        {
            BasketId = basketId;
            CheckIn = checkIn;
            CheckOut = checkOut;
            RoomsCapacity = roomsCapacity;
            CreatedAt = createdAt;
        }

        public void AddRoom(Capacity capacity, RoomType roomType)
        {
            RoomModel model;
            model.capacity = capacity;
            model.roomType = roomType;
            Rooms.Add(model);
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
