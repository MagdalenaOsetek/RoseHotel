using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RoseHotel.Domain.Exceptions;

namespace RoseHotel.Appliction.Exceptions
{
    public class ReservationNotFoundException : RoseHotelException
    {
        public Guid ReservationId { get; set; }
        public ReservationNotFoundException(Guid value) : base($"Cannot find reservation with ID number '{value}'")
        {
            ReservationId = value;
        }
    }
}
