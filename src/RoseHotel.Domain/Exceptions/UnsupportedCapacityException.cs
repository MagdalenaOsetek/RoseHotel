using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoseHotel.Domain.Exceptions
{
    public class UnsupportedCapacityException : RoseHotelException
    {
        public int Capacity { get; }
        public UnsupportedCapacityException(int value) : base($"Capacity '{value}' is unsupported")
        {
            Capacity = value;
        }
    }
}
