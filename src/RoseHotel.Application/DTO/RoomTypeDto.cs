﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoseHotel.Application.DTO
{
    public class RoomTypeDto
    {
        public Guid RoomTypeId { get; set; }
        public string Type { get; set; }
        public decimal Price { get; set; }
        public int Capacity { get; set; }
    }
}
