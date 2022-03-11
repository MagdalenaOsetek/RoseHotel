using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RoseHotel.Application.Abstractions;

namespace RoseHotel.Application.Commands
{
    public record AddRoom(int Number, string Type, decimal Price, int Capacity) : ICommand
    {
        public Guid RoomId { get;  } = Guid.NewGuid();
    }
}
    
