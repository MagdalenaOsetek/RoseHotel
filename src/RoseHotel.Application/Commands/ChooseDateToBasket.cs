using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RoseHotel.Application.Abstractions;

namespace RoseHotel.Application.Commands
{ 
    

    public record ChooseDateToBasket(DateTime CheckIn, DateTime CheckOut, List<int> RoomsCapacity) : ICommand
    {
        public Guid BasketId { get; } = Guid.NewGuid();
    }
}
