using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RoseHotel.Appliction.Abstractions;

namespace RoseHotel.Appliction.Commands
{
    public record AddGuestToBasket(Guid BasketId,string Name, string Surname, string Natinality, string Number, string Email, string Adress, string City, string Country, string Code) : ICommand;
  
}
