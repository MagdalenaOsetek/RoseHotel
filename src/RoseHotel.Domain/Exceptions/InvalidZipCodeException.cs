using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoseHotel.Domain.Exceptions
{
    public class InvalidZipCodeException : RoseHotelException
    {
        public string ZipCode { get; set; }
        public InvalidZipCodeException(string value) : base($"Zip code value '{value}' is invalid")
        {
            ZipCode = value;
        }
    }
}
