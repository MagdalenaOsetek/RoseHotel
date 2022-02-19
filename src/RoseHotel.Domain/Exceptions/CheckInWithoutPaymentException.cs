using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoseHotel.Domain.Exceptions
{
    class CheckInWithoutPaymentException : RoseHotelException
    {
        public CheckInWithoutPaymentException() : base("Cannot check in without fully paid bill")
        {
        }
    }
}
