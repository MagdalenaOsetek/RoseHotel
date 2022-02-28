using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoseHotel.Appliction.DTO
{
    public class ReservationDto
    {

        public Guid ReservationId { get; set; }
        public List<RoomDto> Rooms { get; set; }
        public GuestDto Guest { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public decimal ToPay { get; set; }
        public decimal Paid { get; set; } 
    }
}
