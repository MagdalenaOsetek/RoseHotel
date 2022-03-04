using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RoseHotel.Application.Abstractions;

namespace RoseHotel.Application.Commands
{
    public record AddGuestToBasket(Guid BasketId,string Name, string Surname, string Natinality, string Number, string Email, string Adress, string City, string Country, string Code) : ICommand;
  
}
