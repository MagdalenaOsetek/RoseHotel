using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RoseHotel.Domain.Exceptions;

namespace RoseHotel.Application.Exceptions
{
    public class GuestNotAddedToBasketException : RoseHotelException
    {
        public Guid Id { get; set; }
        public GuestNotAddedToBasketException(Guid value) : base($"Not all guest info where added to basket with Id {value}")
        {
            Id = value;
        }
    }
}
