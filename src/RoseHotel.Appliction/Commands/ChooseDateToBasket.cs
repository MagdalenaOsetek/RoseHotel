using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RoseHotel.Appliction.Abstractions;

namespace RoseHotel.Appliction.Commands
{ 
    

    public record ChooseDateToBasket(DateTime CheckIn, DateTime CheckOut, List<int> RoomsCapacity) : ICommand
    {
        public Guid BasketId { get; } = Guid.NewGuid();
    }
}
