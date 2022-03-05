using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RoseHotel.Application.Abstractions;

namespace RoseHotel.Application.Queries
{
    public record VerifyUser(Guid UserId) : ICommand;
  
}
