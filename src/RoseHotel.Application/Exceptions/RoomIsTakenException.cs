using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RoseHotel.Domain.Exceptions;

namespace RoseHotel.Application.Exceptions
{
    public class RoomIsTakenException : RoseHotelException
    {
        
        public RoomIsTakenException() : base($"Choosen room is already taken")
        {
        }
    }
}
