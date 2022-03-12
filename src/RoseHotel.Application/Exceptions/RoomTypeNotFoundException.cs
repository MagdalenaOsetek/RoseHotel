using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RoseHotel.Domain.Exceptions;

namespace RoseHotel.Application.Exceptions
{
    public class RoomTypeNotFoundException : RoseHotelException
    {
        public Guid  Id{ get; set; }
        public RoomTypeNotFoundException(Guid value) : base($"Room type with id {value} not found")
        {
            Id = value;
        }
    }
}
