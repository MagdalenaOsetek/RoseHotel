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

    public class PayReservationHandlerTests
    {
        [Fact]
        public async Task HandleAsync_Throws_ReservationNotFoundException_When_Reservation_With_Given_Id_IsNot_Found()
        {
            var command = new PayReservation(reservationId, 559.0m, "5191914942157165", DateTime.Today.AddMonths(3), "123", "Magdalena Osetek");
            _reservationRepository.GetAsync(command.ReservationId).Returns(default(Reservation));

            var exception = await Record.ExceptionAsync(() => _handler.HandleAsync(command));

            exception.ShouldNotBeNull();
            exception.ShouldBeOfType<ReservationNotFoundException>();

        }


        [Fact]
        public async Task HandleAsync_Throws_GuestNotFoundException_When_Reservation_With_Given_Id_IsNot_Found()
        {
            var command = new PayReservation(reservationId, 559.0m, "5191914942157165", DateTime.Today.AddMonths(3), "123", "Magdalena Osetek");
            _reservationRepository.GetAsync(command.ReservationId).Returns(GetValidReservation());
            _guestRepository.GetAsync(guestId).Returns(default(Guest));

            var exception = await Record.ExceptionAsync(() => _handler.HandleAsync(command));

            exception.ShouldNotBeNull();
            exception.ShouldBeOfType<GuestNotFoundException>();

        }

        [Fact]
        public async Task HandleAsync_Calls_Repository_On_Success()
        {
            var command = new PayReservation(reservationId, 459.99m, "5191914942157165", DateTime.Today.AddMonths(3), "123", "Magdalena Osetek");
            _reservationRepository.GetAsync(command.ReservationId).Returns(GetValidReservation());
            _guestRepository.GetAsync(guestId).Returns(GetValidGuest());

            var exception = await Record.ExceptionAsync(() => _handler.HandleAsync(command));


            exception.ShouldBeNull();

            await _reservationRepository.Received(1).UpdateAsync(Arg.Is<Reservation>(x => x.Status == "PAID"));
            await _guestRepository.Received(1)
                .UpdateAsync(Arg.Is<Guest>(x => x.Card.CardNumber == "5191914942157165" && x.Card.ExpirationDate == DateTime.Today.AddMonths(3) && x.Card.Cvv == "123" && x.Card.FullName == "Magdalena Osetek"));

        }


        private readonly ICommandHandler<PayReservation> _handler;
        private readonly IReservationRepository _reservationRepository;
        private readonly IGuestRepository _guestRepository;

        public PayReservationHandlerTests()
        {
            _reservationRepository = Substitute.For<IReservationRepository>();
            _guestRepository = Substitute.For<IGuestRepository>();
            _handler = new PayReservationHandler(_reservationRepository, _guestRepository);
        }

        public static Guid reservationId = Guid.NewGuid();
        public static Guid guestId = Guid.NewGuid();

        public static RoomType GetValidRoomType() => new RoomType(Guid.NewGuid(), "LUX", 459.99m, 3);

        public static List<Room> GetValidRoom() => new List<Room>() { new Room(Guid.NewGuid(), 1, GetValidRoomType()) };


        public static Guest GetValidGuest()
          => new(guestId, "Magdalena", "Osetek", DateTime.Now, "test@gmail.com",
              "+48693897274", new Adress("Klejowa", "Szczyrk", "PL", "91-402"));

        public static Reservation GetValidReservation()
           => new(reservationId, GetValidRoom(), GetValidGuest(), DateTime.Today.AddDays(3), DateTime.Today.AddDays(4), DateTime.Now);
    }




}
