using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RoseHotel.Domain.Exceptions;

namespace RoseHotel.Application.Exceptions
{
    public class InvalidCheckInCheckOutException : RoseHotelException
    {
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public InvalidCheckInCheckOutException(DateTime checkIn , DateTime checkOut) : base($"Check in date '{checkIn}' and check out date '{checkOut}' are invalid'")
        {
            CheckIn = checkIn;
            CheckOut = checkOut;
        }
    }
}
