using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoseHotel.Domain.Exceptions
{
    class UnsupportedRoleException : RoseHotelException
    {
        public string Role { get; set; }
        public UnsupportedRoleException(string value) : base($"Role '{value}' is unsupported")
        {
            Role = value;
        }
    }
}
