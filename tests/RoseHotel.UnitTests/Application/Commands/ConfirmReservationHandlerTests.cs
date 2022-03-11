using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NSubstitute;
using RoseHotel.Application.Abstractions;
using RoseHotel.Application.Commands;
using RoseHotel.Application.Exceptions;
using RoseHotel.Domain.Entities;
using RoseHotel.Domain.Repositories;
using RoseHotel.Domain.ValueObjects;
using Shouldly;
using Xunit;

namespace RoseHotel.UnitTests.Application.Commands
{
    public class ConfirmReservationHandlerTests
    {

        [Fact]
        public async Task HandleAsync_Throws_BasketNotFoundException_When_Basket_With_Given_Id_IsNot_Found()
        {
            var command = new ConfirmReservation(basketId);

            _basketRepository.GetAsync(command.BasketId).Returns(default(Basket));

            var exception = await Record.ExceptionAsync(() => _handler.HandleAsync(command));

            exception.ShouldNotBeNull();
            exception.ShouldBeOfType<BasketNotFoundException>();

        }

        [Fact]
        public async Task HandleAsync_Throws_RoomNotAddedToBasketException_When_Count_Of_Rooms_Is_Less_Then_Count_Of_RoomsCapacity()
        {
            var command = new ConfirmReservation(basketId);
            _basketRepository.GetAsync(command.BasketId).Returns(GetBaseBasket());

            var exception = await Record.ExceptionAsync(() => _handler.HandleAsync(command));

            exception.ShouldNotBeNull();
            exception.ShouldBeOfType<RoomNotAddedToBasketException>();

        }

        [Theory]
        [InlineData("Magdalena", "Osetek", "693897274", "test@gmail.com", "Klejowa", "Szczyrk", "PL", "91-402")]
        public async Task HandleAsync_Throws_GuestNotAddedToBasketException_When_Guest_info_Not_Added_To_Basket(string name, string surname, string number, string email, string adress, string city, string country, string code)
        {
            var command = new ConfirmReservation(basketId);
            _basketRepository.GetAsync(command.BasketId).Returns(GetBasketWithRoom());
            _guestRepository.GetAsync(name, surname, number, email, adress, city, country, code).Returns(GetValidGuest());
            _reservationRepository.CheckIfFreeAsync(roomId, DateTime.Today.AddDays(3), DateTime.Today.AddDays(5)).Returns(false);

            var exception = await Record.ExceptionAsync(() => _handler.HandleAsync(command));

            exception.ShouldNotBeNull();
            exception.ShouldBeOfType<GuestNotAddedToBasketException>();

        }





        private readonly ICommandHandler<ConfirmReservation> _handler;
        private readonly IBasketRepository _basketRepository;
        private readonly IReservationRepository _reservationRepository;
        private readonly IGuestRepository _guestRepository;
        private readonly IRoomRepository _roomRepository;
        private readonly IClock _clock;


        public ConfirmReservationHandlerTests(IBasketRepository basketRepository, IReservationRepository reservationRepository, IGuestRepository guestRepository, IRoomRepository roomRepository, IClock clock)
        {
            _basketRepository = Substitute.For<IBasketRepository>();
            _reservationRepository = Substitute.For<IReservationRepository>();
            _guestRepository = Substitute.For<IGuestRepository>();
            _roomRepository = Substitute.For<IRoomRepository>();
            _clock = Substitute.For<IClock>();
        }

        public static Guid basketId = Guid.NewGuid();

        public static Basket GetBaseBasket() => new Basket(basketId, DateTime.Today.AddDays(3), DateTime.Today.AddDays(5), new List<Capacity> { 2 }, DateTime.Now);

        public static Guid roomId = Guid.NewGuid();

        public static Basket GetBasketWithRoom()
        {
            var basket = GetBaseBasket();

            basket.AddRoom(roomId);

            return basket;
        }
        public static Basket GetValidBasket()
        {
            var basket = GetBasketWithRoom();

            basket.AddGuest("Magdalena", "Osetek", "693897274", "test@gmail.com", "Klejowa", "Szczyrk", "PL", "91-402");

            return basket;
        }


        public static Guest GetValidGuest()
          => new(Guid.NewGuid(), "Magdalena", "Osetek", DateTime.Now, "test@gmail.com",
              "693897274", new Adress("Klejowa", "Szczyrk", "PL", "91-402"), new Card("5191914942157165", DateTime.Now.AddMonths(2), "123", "Magdalena Osetek"));
    }
}
