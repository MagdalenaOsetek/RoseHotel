﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RoseHotel.Appliction.Abstractions;
using RoseHotel.Appliction.DTO;

namespace RoseHotel.Appliction.Queries
{
    public class BrowserReservationCheckIn : IQuery<IReadOnlyList<RoomDto>>
    {
        public List<int> RoomsCapacity { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get;  set; }

    }
}