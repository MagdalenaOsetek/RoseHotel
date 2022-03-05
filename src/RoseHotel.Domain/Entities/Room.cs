using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RoseHotel.Domain.ValueObjects;

namespace RoseHotel.Domain.Entities
{
    public class Room
    {
        public Guid RoomId { get; private set; }
        public ICollection<Reservation> Reservations { get; private set; }
        public int Number { get; private set; }
        public RoomType Type { get; private set; }
        public Price Price { get; private set; }
        public Capacity Capacity { get; private set; }

        

        public Room()
        {

        }

        public Room(Guid roomId, ICollection<Reservation> reservations, int number, RoomType type, Price price, Capacity capacity)
        {
            RoomId = roomId;
            Reservations = reservations;
            Number = number;
            Type = type;
            Price = price;
            Capacity = capacity;
        }

        public Room(Guid roomId, int number, RoomType type, Price price, Capacity capacity)
        {
            RoomId = roomId;
            Number = number;
            Type = type;
            Price = price;
            Capacity = capacity;
        }
    }
}
