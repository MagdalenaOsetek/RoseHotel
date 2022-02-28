using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoseHotel.Domain.Exceptions
{
    class InvalidCountryException : RoseHotelException
    {
        public string Country { get; set; }
        public InvalidCountryException(string value) : base($"Country name '{value}' is invalid")
        {
            Country = value;
        }
    }
}
