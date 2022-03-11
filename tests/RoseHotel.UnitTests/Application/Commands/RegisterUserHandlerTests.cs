using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NSubstitute;
using RoseHotel.Application.Abstractions;
using RoseHotel.Application.Commands;
using RoseHotel.Application.Commands.Handlers;
using RoseHotel.Application.Exceptions;
using RoseHotel.Domain.Entities;
using RoseHotel.Domain.Repositories;
using Shouldly;
using Xunit;

namespace RoseHotel.UnitTests.Application.Commands
{
    public class RegisterUserHandlerTests
    {


        [Fact]
        public async Task HandleAsync_Throws_UserAlreadyExistsException_When_User_With_Email_Is_Found()
        {
            var command = new RegisterUser("test@gmail.com", "1234567J!dhdee");
            _userRepository.ExistsAsync(command.Email).Returns(true);

            var exception = await Record.ExceptionAsync(() => _handler.HandleAsync(command));

            exception.ShouldNotBeNull();
            exception.ShouldBeOfType<UserAlreadyExistsException>();

        }

        [Fact]
        public async Task HandleAsync_Calls_Repository_On_Success()
        {
            var command = new RegisterUser("test@gmail.com", "1234567J!dhdee");
            _userRepository.ExistsAsync(command.Email).Returns(false);

            var exception = await Record.ExceptionAsync(() => _handler.HandleAsync(command));

            exception.ShouldBeNull();

            await _userRepository.Received(1).AddAsync(Arg.Is<User>(x => x.Email == "test@gmail.com" && x.Password == "1234567J!dhdee"));


        }

        private readonly ICommandHandler<RegisterUser> _handler;
        private readonly IUserRepository _userRepository;
        private readonly IClock _clock;

        public RegisterUserHandlerTests()
        {
            _userRepository = Substitute.For<IUserRepository>();
            _clock = Substitute.For<IClock>();
            _handler = new RegisterUserHandler(_userRepository, _clock);
        }



    }
}
