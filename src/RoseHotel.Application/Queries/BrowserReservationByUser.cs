using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RoseHotel.Application.Abstractions;
using RoseHotel.Application.DTO;

namespace RoseHotel.Application.Queries
{
    class BrowserReservationByUser : IQuery<IReadOnlyCollection<ReservationDto>>
    {
        public Guid UserId { get; set; }
    }
}
