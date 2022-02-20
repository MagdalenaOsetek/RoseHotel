using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoseHotel.Domain.Exceptions
{
    public class InvaildCvvException : RoseHotelException
    {
        public string Cvv;
        public InvaildCvvException(string value) : base($"Cvv '{value}' is invalid")
        {
            Cvv = value;
        }
    }
}
