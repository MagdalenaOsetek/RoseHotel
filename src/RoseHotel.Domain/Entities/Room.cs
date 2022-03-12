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
        public RoomType RoomType { get; private set; }
        public Guid RoomTypeId { get; private set; }

  

        public Room()
        {

        }


        public Room(Guid roomId, int number,RoomType roomType)
        {
            RoomId = roomId;
            Number = number;
            RoomType = roomType;
            RoomTypeId = roomType.RoomTypeId;

        }
    }
}
