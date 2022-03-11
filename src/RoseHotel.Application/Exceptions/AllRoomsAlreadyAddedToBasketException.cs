using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RoseHotel.Domain.Exceptions;

namespace RoseHotel.Application.Exceptions
{
    public class AllRoomsAlreadyAddedToBasketException : RoseHotelException
    {
        public Guid Id { get; set; }
        public AllRoomsAlreadyAddedToBasketException(Guid value) : base($"All choosen rooms has already been added to basket with Id {value}")
        {
            Id = value;
        }
    }
}
