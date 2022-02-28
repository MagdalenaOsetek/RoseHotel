using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoseHotel.Domain.Exceptions
{
    public class InvalidCityException : RoseHotelException
    {
        public string City { get; set; }
        public InvalidCityException(string value) : base($"City name '{value}' is invalid")
        {
            City = value;
        }
    }
}
