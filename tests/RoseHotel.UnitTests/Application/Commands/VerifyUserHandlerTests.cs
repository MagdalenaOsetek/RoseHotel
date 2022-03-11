using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NSubstitute;
using RoseHotel.Application.Abstractions;
using RoseHotel.Application.Exceptions;
using RoseHotel.Application.Queries;
using RoseHotel.Application.Queries.Handlers;
using RoseHotel.Domain.Entities;
using RoseHotel.Domain.Repositories;
using RoseHotel.Domain.ValueObjects;
using Shouldly;
using Xunit;

namespace RoseHotel.UnitTests.Application.Commands
{
    public class VerifyUserHandlerTests
    {

        [Fact]
        public async Task HandleAsync_Throws_UserNotFoundException_When_User_With_Given_Id_IsNot_Found()
        {
            var command = new VerifyUser(userId);
            _userRepository.GetAsync(command.UserId).Returns(default(User));

            var exception = await Record.ExceptionAsync(() => _handler.HandleAsync(command));

            exception.ShouldNotBeNull();
            exception.ShouldBeOfType<UserNotFoundException>();

        }

        [Fact]
        public async Task HandleAsync_Calls_Repository_On_Success()
        {
            var command = new VerifyUser(userId);
            _userRepository.GetAsync(command.UserId).Returns(GetValidUser());

            var exception = await Record.ExceptionAsync(() => _handler.HandleAsync(command));

            exception.ShouldBeNull();

            await _userRepository.Received(1).UpdateAsync(Arg.Is<User>(x => x.IsVerified==true));
           
                
        }





        private readonly ICommandHandler<VerifyUser> _handler;
        private readonly IUserRepository _userRepository;
        private readonly IClock _clock;

        public VerifyUserHandlerTests()
        {
            _userRepository = Substitute.For<IUserRepository>();
            _clock = Substitute.For<IClock>();
            _handler = new VerifyUserHandler(_userRepository, _clock);
        }

        public static Guid userId = Guid.NewGuid();


        public static User GetValidUser()
            => new(userId, new Guest(Guid.NewGuid()), "test@gmail.com", "1234567J!dhdee", "USER", null, DateTime.Now, null);

    }
}
