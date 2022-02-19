using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoseHotel.Domain.Exceptions
{
    class InvaildCardNumberException : RoseHotelException
    {
        public string CardNumber { get; set; }
        public InvaildCardNumberException(string value) : base($"Card number '{value}' is invalid")
        {
            CardNumber = value;
        }
    }
}
