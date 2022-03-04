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
    public class GetUserHandler : IQueryHandler<GetUser, UserDto>
    {
        private readonly IUserRepository _userRepository;

        public GetUserHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UserDto> HandleAsync(GetUser query)
        {
           var user = await _userRepository.GetAsync(query.Email, query.Password);
            return user.AsDto();
        }
    }
}
