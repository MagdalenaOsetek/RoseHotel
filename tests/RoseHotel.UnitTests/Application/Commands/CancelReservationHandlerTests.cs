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
    public class CancelReservationHandlerTests
    {

        [Fact]
        public async Task HandleAsync_Throws_ReservationNotFoundException_When_Reservation_With_Given_Id_IsNot_Found()
        {
            var command = new CancelReservation(reservationId);
            _reservationRepository.GetAsync(command.ReservationId).Returns(default(Reservation));

            var exception = await Record.ExceptionAsync(() => _handler.HandleAsync(command));

            exception.ShouldNotBeNull();
            exception.ShouldBeOfType<ReservationNotFoundException>();

        }

        [Fact]
        public async Task HandleAsync_Calls_Repository_On_Success()
        {
            var command = new CancelReservation(reservationId);
            _reservationRepository.GetAsync(command.ReservationId).Returns(GetValidReservation());

            var exception = await Record.ExceptionAsync(() => _handler.HandleAsync(command));


            exception.ShouldBeNull();

            await _reservationRepository.Received(1).DeleteAsync(Arg.Is<Reservation>(x => x.ReservationId == command.ReservationId));

        }


        private readonly ICommandHandler<CancelReservation> _handler;
        private readonly IReservationRepository _reservationRepository;

        public CancelReservationHandlerTests()
        {
            _reservationRepository = Substitute.For<IReservationRepository>();
            _handler = new CancelReservationHandler( _reservationRepository);
        }

        public static Guid reservationId = Guid.NewGuid();

        public static List<Room> GetValidRoom() => new List<Room>() { new Room(Guid.NewGuid(), 1, "LUX", 559.0m, 2) };


        public static Guest GetValidGuest()
          => new(Guid.NewGuid(), "Magdalena", "Osetek", DateTime.Now, "test@gmail.com",
              "+48693897274", new Adress("Klejowa", "Szczyrk", "PL", "91-402"), new Card("5191914942157165", DateTime.Now.AddMonths(2), "123", "Magdalena Osetek"));

        public static Reservation GetValidReservation()
           => new(reservationId, GetValidRoom(), GetValidGuest(), DateTime.Now.AddDays(3), DateTime.Now.AddDays(5), DateTime.Now);
    }
}
