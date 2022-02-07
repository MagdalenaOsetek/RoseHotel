using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoseHotel.Domain.Exceptions
{
    public class InvalidPasswordException : RoseHotelException
    {
        public InvalidPasswordException() : base("Password should have at least 8 character and contains at least one digit, lowercase character and uppercase character")
        {
        }
    }
}
