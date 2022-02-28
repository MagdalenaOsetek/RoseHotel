using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RoseHotel.Appliction.Abstractions;
using RoseHotel.Appliction.DTO;

namespace RoseHotel.Appliction.Queries
{
    public class GetRoom : IQuery<RoomDto>
    {
        public Guid RoomId { get; set; }
    }
}
