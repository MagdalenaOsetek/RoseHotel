using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RoseHotel.Domain.Entities;
using RoseHotel.Domain.Exceptions;
using RoseHotel.Domain.ValueObjects;
using Shouldly;
using Xunit;

namespace RoseHotel.UnitTests.Domain
{
    public class ReservationTests
    {

        [Fact]
        public void ChangeStatus_Throws_CheckInWithoutPaymentException_When_Status_Is_Not_Paid_Before_CheckIn()
        {
            var reservation = GetValidReservation();

            reservation.ChangeStatus("VERIFIED");

            var exception = Record.Exception(() => reservation.ChangeStatus("CHECKED IN"));

            exception.ShouldNotBeNull();
            exception.ShouldBeOfType<CheckInWithoutPaymentException>();
        }

        [Fact]
        public void ChangeStatus_Assigns_CheckIn_When_Status_Before_Is_Paid()
        {
            var reservation = GetValidReservation();

            reservation.ChangeStatus("PAID");

            var exception = Record.Exception(() => reservation.ChangeStatus("CHECKED IN"));

            exception.ShouldBeNull();
            string status = reservation.Status;
            status.ShouldBe("CHECKED IN");
        }

        [Theory]
        [InlineData(100, 1018)]
        [InlineData(0, 1118)]
        public void Pay_Assigns_Paid_If_Topay_Equel_Paid(decimal paid, decimal x)
        {
            var reservation = GetValidReservation();

            reservation.Pay(paid);

            var exception = Record.Exception(() => reservation.Pay(x));

            exception.ShouldBeNull();
            string status = reservation.Status;
            status.ShouldBe("PAID");
        }

        [Theory]
        [InlineData(300,200)]
        [InlineData(100,200)]
        public void Pay_Assigns_Paid(decimal paid, decimal x)
        {
            var reservation = GetValidReservation();

            reservation.Pay(paid);

            var exception = Record.Exception(() => reservation.Pay(x));

            exception.ShouldBeNull();
            decimal p = reservation.Paid;
            p.ShouldBe(paid + x);
        }

        [Theory]
        [InlineData(1118, 200)]
        public void Pay_Throws_InvalidAmountException_When_Paid_Sum_X_Greater_Then_ToPay(decimal paid, decimal x)
        {
            var reservation = GetValidReservation();

            reservation.Pay(paid);

            var exception = Record.Exception(() => reservation.Pay(x));

            exception.ShouldNotBeNull();
            exception.ShouldBeOfType<InvalidAmountException>();

        }


        public static List<Room> GetValidRoom() => new List<Room>() { new Room(Guid.NewGuid(), 1, "LUX", 559.0m, 2) };

        public static Reservation GetValidReservation() => new Reservation(Guid.NewGuid(), GetValidRoom(), GuestTests.GetValidGuest(), DateTime.Now, DateTime.Now.AddDays(2), DateTime.Now );

        
    }
}
