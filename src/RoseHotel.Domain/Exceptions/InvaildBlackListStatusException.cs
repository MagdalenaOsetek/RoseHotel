using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoseHotel.Domain.Exceptions
{
    public class InvaildBlackListStatusException : RoseHotelException
    {
        public string Fullname { get; set; }
        public InvaildBlackListStatusException(string value) : base($"Cannot change guest '{value}' black list status")
        {
            Fullname = value;
        }
    }
}
