using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoseHotel.Domain.Exceptions
{
   public class InvaildOwnerNameException : RoseHotelException
    {
       
        public InvaildOwnerNameException() : base("Name cannot be emapty")
        {
            
        }
    }
}
