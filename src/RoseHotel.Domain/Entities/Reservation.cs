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
        public Guid GuestId { get; private set; }
        public DateTime CheckIn { get; private set; }
        public DateTime CheckOut { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public Amount ToPay { get; private set; }
        public Amount Paid { get; private set; } = 0.0m;

        public ReservationStatus Status { get; private set; } = "UNVERIFIED";

        public Reservation()
        {
        }



        public Reservation(Guid reservationId, ICollection<Room> rooms, Guest guest, DateTime checkIn, DateTime checkOut, DateTime createdAt)
        {
            ReservationId = reservationId;
            Rooms = rooms;
            Guest = guest;
            GuestId = guest.GuestId;
            CheckIn = checkIn;
            CheckOut = checkOut;
            CreatedAt = createdAt;
            ToPay = Decimal.Multiply(rooms.Sum(x =>  x.RoomType.Price),(int)(checkOut - checkIn).TotalDays);
            Paid = 0.0m;

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

            if (Paid.Value > 0)
            {
                Status = "VERIFIED";
            }

            if (Paid.Value == ToPay.Value)
            {
                Status = "PAID";
            }


        }





    }
}
