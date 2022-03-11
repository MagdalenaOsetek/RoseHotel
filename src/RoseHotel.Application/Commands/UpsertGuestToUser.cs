using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RoseHotel.Application.Abstractions;

namespace RoseHotel.Application.Commands
{
    public record UpsertGuestToUser(Guid UserId, string Name, string Surname, string Number, string Adress, string City, string Country, string Code) : ICommand
    {
        public Guid GuestId { get; } = Guid.NewGuid();
    }

}
