using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RoseHotel.Domain.Exceptions;

namespace RoseHotel.Application.Exceptions
{
    public class UserAlreadyExistsException : RoseHotelException
    {

        public string Email { get; set; }
        public UserAlreadyExistsException(string value) : base($"User wtih email '{value}' already exists")
        {
            Email = value;
        }
    }
}
