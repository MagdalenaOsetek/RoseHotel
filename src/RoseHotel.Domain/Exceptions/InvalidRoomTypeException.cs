using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoseHotel.Domain.Exceptions
{
    public class InvalidRoomTypeException : RoseHotelException
    {
        public string RoomType { get; }
        public InvalidRoomTypeException(string value) : base($"Room type '{value}' is invalid.")
        {
            RoomType = value;
        }
    }
}
