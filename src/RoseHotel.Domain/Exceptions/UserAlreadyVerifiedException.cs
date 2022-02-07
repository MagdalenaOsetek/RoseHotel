using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoseHotel.Domain.Exceptions
{
    public class UserAlreadyVerifiedException : RoseHotelException
    {
        public Guid User { get; }
        public UserAlreadyVerifiedException(Guid value) : base($"User with Id '{value}' has already been verified")
        {
            User = value;
        }
    }
}
