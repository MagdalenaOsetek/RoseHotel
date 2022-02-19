﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoseHotel.Domain.Exceptions
{
    class CardExpiredException : RoseHotelException
    {
        public CardExpiredException() : base("Card has expired")
        {
        }
    }
}
