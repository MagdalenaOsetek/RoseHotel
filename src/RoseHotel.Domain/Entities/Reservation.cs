using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RoseHotel.Domain.Exceptions;
using RoseHotel.Domain.ValueObjects;

namespace RoseHotel.Domain.Entities
{
    public class Reservation
    {
        public Guid ReservationId { get; private set; }
        public ICollection<Room> Rooms { get; private set; }
        public Guest Guest { get; private set; }
        public DateTime CheckIn { get; private set; }
        public DateTime CheckOut { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public Amount ToPay { get; private set; }
        public Amount Paid { get; private set; } = 0.0m;

        public ReservationStatus Status { get; private set; } = "UNVERIFIED";

        public Reservation(Guid reservationId, ICollection<Room> rooms, Guest guest, DateTime checkIn, DateTime checkOut, DateTime createdAt)
        {
            ReservationId = reservationId;
            Rooms = rooms;
            Guest = guest;
            CheckIn = checkIn;
            CheckOut = checkOut;
            CreatedAt = createdAt;
            ToPay = Decimal.Multiply(rooms.Sum(x => x.Price),(decimal)(checkOut - checkIn).TotalDays);

        }

        public void ChangeStatus (ReservationStatus reservationStatus)
        {
            if(reservationStatus== "CHECKED IN" && Status != "PAID")
            {
                throw new CheckInWithoutPaymentException();

            }

            Status = reservationStatus;

        }


        public void Pay (Amount amount)
        {
            if(amount + Paid >ToPay)
            {
                throw new InvalidAmountException(amount);
            }

            Paid += amount;

            if(Paid == ToPay)
            {
                Status = "PAID";
            }
        }





    }
}
