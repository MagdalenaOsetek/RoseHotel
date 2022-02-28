using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RoseHotel.Appliction.Abstractions;
using RoseHotel.Appliction.DTO;

namespace RoseHotel.Appliction.Queries
{
    class BrowserReservationByUser : IQuery<IReadOnlyCollection<ReservationDto>>
    {
        public Guid UserId { get; set; }
    }
}
