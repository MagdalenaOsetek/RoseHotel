using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RoseHotel.Application.Abstractions;
using RoseHotel.Application.Exceptions;
using RoseHotel.Domain.Entities;
using RoseHotel.Domain.Repositories;
using RoseHotel.Domain.ValueObjects;

namespace RoseHotel.Application.Commands.Handlers
{
    public class UpsertGuestToUserHandler : ICommandHandler<UpsertGuestToUser>
    {
        private readonly IUserRepository _userRepository;
        private readonly IGuestRepository _guestRepository;
        private readonly IClock _clock;

        public UpsertGuestToUserHandler(IUserRepository userRepository, IGuestRepository guestRepository, IClock clock)
        {
            _userRepository = userRepository;
            _guestRepository = guestRepository;
            _clock = clock;
        }
        public async Task HandleAsync(UpsertGuestToUser command)
        {
            var (userId, name, surname,  number, adress, city, country, code) = command;
            var user = await _userRepository.GetAsync(userId);

            if (user is null)
            {
                throw new UserNotFoundException(userId);
            }

            if(!user.IsVerified)
            {
                throw new UserNotVerifiedException(user.Email);
            }

            var guest = await _guestRepository.GetAsync(user.GuestId);


            guest.AddInfo(name, surname, user.Email, number, adress, city, country, code, _clock.GetCurrentTime());


            await _guestRepository.UpdateAsync(guest);
          
        }
    }
}
