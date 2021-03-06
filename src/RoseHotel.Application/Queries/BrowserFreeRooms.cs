using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RoseHotel.Application.Abstractions;
using RoseHotel.Application.DTO;

namespace RoseHotel.Application.Queries
{
    public class BrowserFreeRooms : IQuery<IReadOnlyCollection<RoomTypeDto>>
    {
        public int RoomCapacity { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get;  set; }

    }
}
