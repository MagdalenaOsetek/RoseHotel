using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RoseHotel.Application.Abstractions;
using RoseHotel.Application.DTO;

namespace RoseHotel.Application.Queries
{
    public class AuthenticateUser: IQuery<UserDto>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
