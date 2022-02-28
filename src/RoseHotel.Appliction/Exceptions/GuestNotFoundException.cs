using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RoseHotel.Domain.Exceptions;

namespace RoseHotel.Appliction.Exceptions
{
    public class GuestNotFoundException : RoseHotelException
    {
        public Guid GuestId { get; set; }
        public GuestNotFoundException(Guid value) : base($"Cannot find guest with Id '{value}'")
        {
            GuestId = value;
        }
    }
}
