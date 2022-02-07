using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoseHotel.Domain.Exceptions
{
    public abstract class RoseHotelException : Exception
    {
        protected RoseHotelException(string message) : base(message)
        {

        }
    }
}
