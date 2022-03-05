using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RoseHotel.Domain.Exceptions;

namespace RoseHotel.Application.Exceptions
{
    public class UserNotVerifiedException : RoseHotelException
    {
        public string  Email { get; set; }
        public UserNotVerifiedException(string value) : base($"User with email '{value}' is not yet verified ")
        { 
           Email = value;
        }
    }
}
