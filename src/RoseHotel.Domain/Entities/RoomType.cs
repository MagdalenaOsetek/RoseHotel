using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RoseHotel.Domain.ValueObjects;

namespace RoseHotel.Domain.Entities
{
    public class RoomType
    {
        public Guid RoomTypeId { get; private set; }
        public RoomTypeName Type { get; private set; }
        public Price Price { get; private set; }
        public Capacity Capacity { get; private set; }

        public ICollection<Room> Rooms { get; private set; }

        public RoomType()
        {

        }

        public RoomType(Guid roomTypeId, RoomTypeName type, Price price, Capacity capacity)
        {
            RoomTypeId = roomTypeId;
            Type = type;
            Price = price;
            Capacity = capacity;
        }
    }
}
