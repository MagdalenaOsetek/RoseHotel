using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RoseHotel.Domain.Exceptions;

namespace RoseHotel.Application.Exceptions
{
    public class BasketNotFoundException : RoseHotelException
    {
        public Guid Id { get; set; }
        public BasketNotFoundException(Guid value) : base($"Basket with Id {value} not found")
        {
            Id = value;
        }
    }
}
