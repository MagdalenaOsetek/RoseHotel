using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoseHotel.Domain.Exceptions
{
    public class InvalidPhoneNumberException : RoseHotelException
    {
        public string PhoneNumber { get; }
        public InvalidPhoneNumberException(string value) : base($"Phone number '{value} is invalid'")
        {
            PhoneNumber = value;
        }
    }
}
