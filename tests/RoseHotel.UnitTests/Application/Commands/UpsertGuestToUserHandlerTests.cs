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
using RoseHotel.Domain.ValueObjects;
using Shouldly;
using Xunit;

namespace RoseHotel.UnitTests.Application.Commands
{
    public class UpsertGuestToUserHandlerTests
    {

        [Theory]
        [InlineData("Magdalena", "Osetek", "693897274", "Klejowa", "Szczyrk", "PL", "91-402")]
        public async Task HandleAsync_Throws_UserNotFoundException_When_User_With_Given_Id_IsNot_Found(string name, string surname, string number, string adress, string city, string country, string code)
        {
            var command = new UpsertGuestToUser(userId, name, surname, number, adress, city, country, code);
            _userRepository.GetAsync(command.UserId).Returns(default(User));

            var exception = await Record.ExceptionAsync(() => _handler.HandleAsync(command));

            exception.ShouldNotBeNull();
            exception.ShouldBeOfType<UserNotFoundException>();

        }

        [Theory]
        [InlineData("Magdalena", "Osetek", "693897274", "Klejowa", "Szczyrk", "PL", "91-402")]
        public async Task HandleAsync_Throws_UserNotVerifiedException_When_User_Is_Not_Verified(string name, string surname, string number, string adress, string city, string country, string code)
        {
            var command = new UpsertGuestToUser(userId, name, surname, number, adress, city, country, code);
            _userRepository.GetAsync(command.UserId).Returns(GetNotVerifiedUser());

            var exception = await Record.ExceptionAsync(() => _handler.HandleAsync(command));

            exception.ShouldNotBeNull();
            exception.ShouldBeOfType<UserNotVerifiedException>();

        }


        [Theory]
        [InlineData("Magdalena", "Osetek", "693897274", "Klejowa", "Szczyrk", "PL", "91-402")]
        public async Task HandleAsync_Calls_Repository_On_Success(string name, string surname, string number, string adress, string city, string country, string code)
        {
            var command = new UpsertGuestToUser(userId, name, surname, number, adress, city, country, code);
             _userRepository.GetAsync(command.UserId).Returns(GetVerifiedUser());
            _guestRepository.GetAsync(guestId).Returns(GetValidGuest());

            var exception = await Record.ExceptionAsync(() => _handler.HandleAsync(command));

            exception.ShouldBeNull();
  await _guestRepository.Received(1).UpdateAsync(Arg.Is<Guest>(x => x.GuestId == guestId &&
            x.Name == name && x.Surname == surname && x.PhoneNumber == number && x.Adress.Street == adress && x.Adress.City == city && x.Adress.Country == country && x.Adress.ZipCode == code));
          


        }





        private readonly ICommandHandler<UpsertGuestToUser> _handler;
        private readonly IUserRepository _userRepository;
        private readonly IGuestRepository _guestRepository;
        private readonly IClock _clock;

        public UpsertGuestToUserHandlerTests()
        {
            _userRepository = Substitute.For<IUserRepository>();
            _guestRepository = Substitute.For<IGuestRepository>();
            _clock = Substitute.For<IClock>();
            _handler = new UpsertGuestToUserHandler(_userRepository, _guestRepository, _clock);
        }

        public static Guid userId = Guid.NewGuid();
        public static Guid guestId = Guid.NewGuid();

        public static Guest GetValidGuest()
             => new(guestId);

        public static User GetNotVerifiedUser()
            => new(userId, GetValidGuest(), "test@gmail.com", "1234567J!dhdee", "USER", null, DateTime.Now, null);

        public static User GetVerifiedUser()
        {
            var user = GetNotVerifiedUser();
            user.Verify(DateTime.Now);
            return user;
        }
    }
}
