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
        public List<Guid> RoomsTypes { get; private set; } = new List<Guid>();
        public Guid UserId { get; private set; }
        public string Name { get; private set; }
        public string Surname { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public Email Email { get; private set; }
        public PhoneNumber PhoneNumber { get; private set; }
        public Adress Adress { get; private set; }


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

        public void AddRoom(Guid roomType)
        {
            RoomsTypes.Add(roomType);
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
