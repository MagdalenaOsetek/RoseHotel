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
        public Guid Id { get; private set; }
        public int number { get; private set; }
        public RoomType type { get; private set; }
        public Price price { get; private set; }
        public Capacity capacity { get; private set; }

        public Room()
        {

        }

        public Room(Guid id, int number, RoomType type, Price price, Capacity capacity)
        {
            Id = id;
            this.number = number;
            this.type = type;
            this.price = price;
            this.capacity = capacity;
        }
    }
}
