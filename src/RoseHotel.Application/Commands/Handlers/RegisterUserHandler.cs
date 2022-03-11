using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RoseHotel.Application.Abstractions;
using RoseHotel.Application.Exceptions;
using RoseHotel.Domain.Entities;
using RoseHotel.Domain.Repositories;

namespace RoseHotel.Application.Commands.Handlers
{
    public class RegisterUserHandler : ICommandHandler<RegisterUser>
    {
        private readonly IUserRepository _userRepository;
        private readonly IClock _clock;

        public RegisterUserHandler(IUserRepository userRepository, IClock clock)
        {
            _userRepository = userRepository;
            _clock = clock;
        }
        public async Task HandleAsync(RegisterUser command)
        {
            var (email, password) = command;

            var userExists = await _userRepository.ExistsAsync(email);

            if(userExists)
            {
                throw new UserAlreadyExistsException(email);
            }

            var guest = new Guest(command.GuestId);

            var user = new User(command.UserId,guest, email, password, "USER",null, _clock.GetCurrentTime(), null);

            await _userRepository.AddAsync(user);

        }
    }
}
