using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoseHotel.Domain.Exceptions
{
    public class InvalidEmailException : RoseHotelException
    {
        public string Email { get; }
        public InvalidEmailException(string value) : base($"Email '{value}' is invalid")
        {
            Email = value;
        }
    }
}
