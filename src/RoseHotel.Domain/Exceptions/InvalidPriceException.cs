using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoseHotel.Domain.Exceptions
{
    public class InvalidPriceException : RoseHotelException
    {

        public decimal Price { get; }
        public InvalidPriceException(decimal value) : base($"Price '{value}' is invalid")
        {
            Price = value;
        }




    }
}
