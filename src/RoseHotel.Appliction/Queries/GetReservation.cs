using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RoseHotel.Appliction.Abstractions;
using RoseHotel.Appliction.DTO;

namespace RoseHotel.Appliction.Queries
{
    class GetReservation : IQuery<ReservationDto>
    {
        public Guid ReservationId { get; set; }
    }
}
