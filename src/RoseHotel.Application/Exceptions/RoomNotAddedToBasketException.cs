using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RoseHotel.Domain.Exceptions;

namespace RoseHotel.Application.Exceptions
{
    public class RoomNotAddedToBasketException : RoseHotelException
    {
        public Guid Id { get; set; }
        public RoomNotAddedToBasketException(Guid value) : base($"Not all rooms where added to basket with Id {value}")
        {
            Id = value;
        }
    }
}
