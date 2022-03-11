using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RoseHotel.Application.Abstractions;
using RoseHotel.Application.DTO;
using RoseHotel.Domain.Repositories;

namespace RoseHotel.Application.Queries.Handlers
{
    internal sealed class AuthenticateUserHandler : IQueryHandler<AuthenticateUser, UserDto>
    {
        private readonly IUserRepository _userRepository;

        public AuthenticateUserHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async  Task<UserDto> HandleAsync(AuthenticateUser query)
        {
           var user = await _userRepository.AuthenticateAsync(query.Email, query.Password);

           return user.AsDto();
        }
    }
}
