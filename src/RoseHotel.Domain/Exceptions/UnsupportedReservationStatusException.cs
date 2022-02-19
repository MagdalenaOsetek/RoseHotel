using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoseHotel.Domain.Exceptions
{
    class UnsupportedReservationStatusException : RoseHotelException
    {
        public string ReservationStatus  { get; }
        public UnsupportedReservationStatusException(string  value) : base($"Reservation Status '{value}' is unsupported")
        {
            ReservationStatus = value;
        }
    }
}
