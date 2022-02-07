using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoseHotel.Domain.Entities
{
    class Reservation
    {
        public Guid Id { get; private set; }
        public Guid RoomId { get; private set; }
        public Guid GuestId { get; private set; }
        public DateTime CheckIn { get; private set; }
        public DateTime CheckOut { get; private set; }
        public DateTime CreatedAt { get; private set; }

        public Reservation(Guid id, Guid roomId, Guid guestId, DateTime checkIn, DateTime checkOut, DateTime createdAt)
        {
            Id = id;
            RoomId = roomId;
            GuestId = guestId;
            CheckIn = checkIn;
            CheckOut = checkOut;
            CreatedAt = createdAt;
        }
    }
}
