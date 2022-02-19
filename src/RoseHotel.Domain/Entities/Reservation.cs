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
        public Amount Paid { get; private set; }

        public  ReservationStatus Status { get; private set; }


        


        public void ChangeStatus (ReservationStatus reservationStatus)
        {
            if(reservationStatus=="CHECK IN" && Status != "PAID")
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
                ChangeStatus("PAID");
            }
        }





    }
}
