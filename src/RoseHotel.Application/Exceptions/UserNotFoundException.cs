using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RoseHotel.Domain.Exceptions;

namespace RoseHotel.Application.Exceptions
{
    public class UserNotFoundException : RoseHotelException
    {
        public Guid Id { get; set; }
        public UserNotFoundException(Guid value) : base($"User with id '{value}' already exists")
        {
            Id = value;
        }
    }
}
