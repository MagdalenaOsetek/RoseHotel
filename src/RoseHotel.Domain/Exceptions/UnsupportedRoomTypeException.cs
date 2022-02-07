using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoseHotel.Domain.Exceptions
{
    public class UnsupportedRoomTypeException : RoseHotelException
    {
        public string RoomType { get; }

        public UnsupportedRoomTypeException(string value) : base($"Room type '{value}' is unsupported")
        {
            RoomType = value;
        }
    }
}
