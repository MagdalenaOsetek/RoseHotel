using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RoseHotel.Application.Abstractions;
using RoseHotel.Application.Exceptions;
using RoseHotel.Domain.Repositories;

namespace RoseHotel.Application.Queries.Handlers
{
    public class VerifyUserHandler : ICommandHandler<VerifyUser>
    {
        private readonly IUserRepository _userRepository;
        private readonly IClock _clock;

        public VerifyUserHandler(IUserRepository userRepository, IClock clock)
        {
            _userRepository = userRepository;
            _clock = clock;
        }
        public async Task HandleAsync(VerifyUser command)
        {
          
            var user = await _userRepository.GetAsync(command.UserId);

            if (user is null)
            {
                throw new UserNotFoundException(command.UserId);
            }

            user.Verify(_clock.GetCurrentTime());
            await _userRepository.UpdateAsync(user);
        }
    }
}
