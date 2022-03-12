using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RoseHotel.Application.Abstractions;
using RoseHotel.Application.DTO;
using RoseHotel.Domain.Entities;

namespace RoseHotel.Application.Queries
{
    public class BrowserRoomType : IQuery<IReadOnlyCollection<RoomTypeDto>>
    {
    }
}
