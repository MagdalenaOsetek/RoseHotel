using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoseHotel.Domain.Exceptions
{
    public class InvalidStreetException : RoseHotelException
    {
        public string Street { get; set; }
        public InvalidStreetException(string value) : base($"Street name '{value} is invalid'")
        {
            Street = value;
        }
    }
}
