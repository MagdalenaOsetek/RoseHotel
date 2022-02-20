using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoseHotel.Domain.Exceptions
{
   public  class InvalidAmountException : RoseHotelException
    {
        public decimal Amount { get; }
        public InvalidAmountException(decimal value) : base($"Amount '{value}' is invalid")
        {
            Amount = value;
        }
    }
}
