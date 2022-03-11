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
        public void Pay_Assigns_Paid_If_Topay_Equel_Paid_And_Assigns_Paid_Status(decimal paid, decimal x)
        {
            var reservation = GetValidReservation();

            reservation.Pay(paid);

            var exception = Record.Exception(() => reservation.Pay(x));

            exception.ShouldBeNull();
            string status = reservation.Status;
            decimal r = reservation.Paid;
            status.ShouldBe("PAID");
        }

        [Theory]
        [InlineData(300, 200)]
        [InlineData(100, 200)]
        public void Pay_Assigns_Paid_And_Status_Verified(decimal paid, decimal x)
        {
            var reservation = GetValidReservation();

            reservation.Pay(paid);

            var exception = Record.Exception(() => reservation.Pay(x));

            exception.ShouldBeNull();
            decimal p = reservation.Paid;
            p.ShouldBe(paid + x);
            string status = reservation.Status;
            status.ShouldBe("VERIFIED");
           
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

      
        public static Guest GetValidGuest()
          => new(Guid.NewGuid(), "Magdalena", "Osetek", DateTime.Now, "test@gmail.com",
              "+48693897274", new Adress("Klejowa", "Szczyrk", "PL", "91-402"), new Card("5191914942157165", DateTime.Now.AddMonths(2), "123", "Magdalena Osetek"));

        public static Reservation GetValidReservation()
            => new(Guid.NewGuid(), GetValidRoom(), GetValidGuest(), DateTime.Now.AddDays(3), DateTime.Now.AddDays(5), DateTime.Now);
         


    }
}
