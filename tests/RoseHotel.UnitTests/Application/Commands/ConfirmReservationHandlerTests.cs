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
        public async Task HandleAsync_Throws_GuestNotAddedToBasketException_When_Guest_Info_Not_Added(string name, string surname, string number, string email, string adress, string city, string country, string code)
        {
            var command = new ConfirmReservation(basketId);
            var basket = GetBasketWithRoom();
            _basketRepository.GetAsync(command.BasketId).Returns(basket);
            _reservationRepository.GetFreeRoomAsync(basket.RoomsTypes.First(), basket.CheckIn, basket.CheckOut).Returns(default(Room));

            var exception = await Record.ExceptionAsync(() => _handler.HandleAsync(command));

            exception.ShouldNotBeNull();
            exception.ShouldBeOfType<GuestNotAddedToBasketException>();

        }

        [Theory]
        [InlineData("Magdalena", "Osetek", "693897274", "test@gmail.com", "Klejowa", "Szczyrk", "PL", "91-402")]
        public async Task HandleAsync_Throws_RoomIsTakenException_When_Room_Not_Found(string name, string surname, string number, string email, string adress, string city, string country, string code)
        {
            var command = new ConfirmReservation(basketId);
            var basket = GetValidBasket();
            _basketRepository.GetAsync(command.BasketId).Returns(basket);
            _guestRepository.GetAsync(name, surname, number, email, adress, city, country, code).Returns(GetValidGuest());
            _reservationRepository.GetFreeRoomAsync(basket.RoomsTypes.First(), basket.CheckIn, basket.CheckOut).Returns(default(Room));

            var exception = await Record.ExceptionAsync(() => _handler.HandleAsync(command));

            exception.ShouldNotBeNull();
            exception.ShouldBeOfType<RoomIsTakenException>();

        }

        [Theory]
        [InlineData("Magdalena", "Osetek", "693897274", "test@gmail.com", "Klejowa", "Szczyrk", "PL", "91-402")]
        public async Task HandleAsync_Calls_Repository_On_Success(string name, string surname, string number, string email, string adress, string city, string country, string code)
        {
            var command = new ConfirmReservation(basketId);
            var basket = GetValidBasket();
            _basketRepository.GetAsync(command.BasketId).Returns(basket);
            _guestRepository.GetAsync(name, surname, number, email, adress, city, country, code).Returns(GetValidGuest());
            _reservationRepository.GetFreeRoomAsync(basket.RoomsTypes.First(), basket.CheckIn, basket.CheckOut).Returns(GetValidRoom());

            var exception = await Record.ExceptionAsync(() => _handler.HandleAsync(command));


            var r = GetValidRoom();
            exception.ShouldBeNull();

            
            //await _reservationRepository.Received(1).AddAsync(Arg.Is<Reservation>( x =>
            //       x.Guest.Name == name && x.Guest.Surname == surname && x.CheckIn == basket.CheckIn && x.CheckOut == basket.CheckOut && x.Rooms.Contains(GetValidRoom())));

           
            await _basketRepository.Received(1).DeleteAsync(Arg.Is<Guid>(x => x == command.BasketId));
        }





        private readonly ICommandHandler<ConfirmReservation> _handler;
        private readonly IBasketRepository _basketRepository;
        private readonly IReservationRepository _reservationRepository;
        private readonly IGuestRepository _guestRepository;
        private readonly IRoomRepository _roomRepository;
        private readonly IClock _clock;


        public ConfirmReservationHandlerTests()
        {
            _basketRepository = Substitute.For<IBasketRepository>();
            _reservationRepository = Substitute.For<IReservationRepository>();
            _guestRepository = Substitute.For<IGuestRepository>();
            _roomRepository = Substitute.For<IRoomRepository>();
            _clock = Substitute.For<IClock>();
            _handler = new ConfirmReservationHandler(_basketRepository, _reservationRepository, _guestRepository, _roomRepository, _clock);
        }





        public static Guid basketId = Guid.NewGuid();

        public static Guid roomTypeId = Guid.NewGuid();

        public static Guid roomId = Guid.NewGuid();

        public static RoomType GetValidRoomType() => new RoomType(roomTypeId, "LUX", 459.99m, 3);

        public static Room GetValidRoom() => new Room(roomId, 1, GetValidRoomType()) ;
        public static Basket GetBaseBasket() => new Basket(basketId, DateTime.Today.AddDays(3), DateTime.Today.AddDays(5), new List<Capacity> { 2 }, DateTime.Now);

 
        public static Basket GetBasketWithRoom()
        {
            var basket = GetBaseBasket();

            basket.AddRoom(roomTypeId);

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
