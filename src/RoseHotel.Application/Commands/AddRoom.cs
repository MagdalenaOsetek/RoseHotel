using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RoseHotel.Application.Abstractions;

namespace RoseHotel.Application.Commands
{
    public record AddRoom(int Number, Guid RoomType) : ICommand
    {
        public Guid RoomId { get;  } = Guid.NewGuid();
    }
}
    
