using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RoseHotel.Domain.Exceptions;

namespace RoseHotel.Application.Exceptions
{
    public class RoomNotFoundException : RoseHotelException
    {
        public Guid Id { get; set; }
        public RoomNotFoundException(Guid value) : base($"Room with Id {value} cannot be found")
        {
            Id = value;
        }
    }
}
