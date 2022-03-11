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
    public class AddRoomToBasketHandlerTests
    {



        [Fact]
        public async Task HandleAsync_Throws_RoomNotFoundException_When_Room_With_Given_Id_IsNot_Found()
        {
            var command = new AddRoomToBasket(basketId, roomId);
            _roomRepository.ExistsAsync(command.RoomId).Returns(false);

            var exception = await Record.ExceptionAsync(() => _handler.HandleAsync(command));

            exception.ShouldNotBeNull();
            exception.ShouldBeOfType<RoomNotFoundException>();

        }

        [Fact]
        public async Task HandleAsync_Throws_BasketNotFoundException_When_Basket_With_Given_Id_IsNot_Found()
        {
            var command = new AddRoomToBasket(basketId,roomId);
            var room = GetValidRoom();
            _roomRepository.ExistsAsync(command.RoomId).Returns(true);
            _basketRepository.GetAsync(command.BasketId).Returns(default(Basket));

            var exception = await Record.ExceptionAsync(() => _handler.HandleAsync(command));

            exception.ShouldNotBeNull();
            exception.ShouldBeOfType<BasketNotFoundException>();

        }


        [Fact]
        public async Task HandleAsync_Throws_AllRoomsAlreadyAddedToBasketException_When_Basket_Has_As_Many_Rooms_As_Count_Of_RoomsCapacity()
        {
            var command = new AddRoomToBasket(basketId, roomId);
            var room = GetValidRoom();
            _roomRepository.ExistsAsync(command.RoomId).Returns(true);
            _basketRepository.GetAsync(command.BasketId).Returns(GetBasketWithAllRooms());

            var exception = await Record.ExceptionAsync(() => _handler.HandleAsync(command));

            exception.ShouldNotBeNull();
            exception.ShouldBeOfType<AllRoomsAlreadyAddedToBasketException>();

        }



        [Fact]
        public async Task HandleAsync_Calls_Repository_On_Success()
        {
            var command = new AddRoomToBasket(basketId, roomId);
            var room = GetValidRoom();
            _roomRepository.ExistsAsync(command.RoomId).Returns(true);
            var basket = GetValidBasket();
            _basketRepository.GetAsync(command.BasketId).Returns(basket);


            var exception = await Record.ExceptionAsync(() => _handler.HandleAsync(command));

            exception.ShouldBeNull();

            await _basketRepository.Received(1).UpdateAsync(Arg.Is<Basket>(x => x.Rooms.Contains(command.RoomId)));

        }



        private readonly ICommandHandler<AddRoomToBasket> _handler;
        private readonly IBasketRepository _basketRepository;
        private readonly IRoomRepository _roomRepository;
        private readonly IReservationRepository _reservationRepository;

        public AddRoomToBasketHandlerTests()
        {
            _basketRepository = Substitute.For<IBasketRepository>();
            _roomRepository = Substitute.For<IRoomRepository>();
            _reservationRepository = Substitute.For<IReservationRepository>();
            _handler = new AddRoomToBasketHandler(_basketRepository, _roomRepository, _reservationRepository);
        }

        public static Guid roomId = Guid.NewGuid();
        public static Guid basketId = Guid.NewGuid();
        public static Room GetValidRoom() => new Room(roomId, 1, "LUX", 559.0m, 2);

        public static Basket GetValidBasket() => new Basket(basketId, DateTime.Now.AddDays(3), DateTime.Now.AddDays(5), new List<Capacity> { 2 }, DateTime.Now);

        public static Basket GetBasketWithAllRooms()
        {
            var basket = GetValidBasket();
            basket.AddRoom(Guid.NewGuid());
            return basket;
        }
    }



}
