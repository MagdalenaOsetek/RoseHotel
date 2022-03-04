using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RoseHotel.Application.Abstractions;

namespace RoseHotel.Application.Commands
{
    public record ConfirmReservation(Guid BasketId) : ICommand
    {
        public Guid GuestId { get; } = Guid.NewGuid();
        public Guid ReservationId { get; } = Guid.NewGuid();
    }
  
}
