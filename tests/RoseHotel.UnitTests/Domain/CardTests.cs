using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RoseHotel.Domain.ValueObjects;
using RoseHotel.Domain.Exceptions;
using Shouldly;
using Xunit;

namespace RoseHotel.UnitTests.Domain
{
    public class CardTests
    {

        public static DateTime date1 = new DateTime(2008, 5, 1, 8, 30, 52);

        [Theory]
        [InlineData("456940396114710", "1988-05-01", "55!", "")]
        [InlineData("45694039_61014710", "1988-05-01", "55!", "")]
        [InlineData("45694039610147104444", "1988-05-01", "55!", "")]
        public void Card_Should_Throw_InvalidCardNumberException_When_CardNumber_Is_Invalid(string number, string date, string cvv, string fullname)
        {
            var exception = Record.Exception(() => new Card(number, DateTime.Parse(date), cvv, fullname));

            exception.ShouldNotBeNull();
            exception.ShouldBeOfType<InvaildCardNumberException>();
        }


        [Theory]
        [InlineData("5191914942157165", "1988-05-31", "55!", "")]
        [InlineData("6011000000000000", "2022-01-31", "55!", "")]
        [InlineData("3566002020360505", "2021-05-31", "55!", "")]
        public void Card_Should_Throw_CardExpiredException_When_ExpirationDate_Is_Before_Now(string number, string date, string cvv, string fullname)
        {
            var exception = Record.Exception(() => new Card(number, DateTime.Parse(date), cvv, fullname));

            exception.ShouldNotBeNull();
            exception.ShouldBeOfType<CardExpiredException>();
        }

        [Theory]
        [InlineData("5191914942157165", "2022-05-31", "55", "")]
        [InlineData("6011000000000000", "2024-01-31", "abc", "")]
        [InlineData("3566002020360505", "2023-05-31", "34211", "")]
        public void Card_Should_Throw_InvaildCvvException_When_Cvv_Is_Invalid(string number, string date, string cvv, string fullname)
        {
            var exception = Record.Exception(() => new Card(number, DateTime.Parse(date), cvv, fullname));

            exception.ShouldNotBeNull();
            exception.ShouldBeOfType<InvaildCvvException>();
        }


        [Theory]
        [InlineData("5191914942157165", "2022-05-31", "123", "")]
        public void Card_Should_Throw_InvaildOwnerNameException_When_Fullname_Is_Invalid(string number, string date, string cvv, string fullname)
        {
            var exception = Record.Exception(() => new Card(number, DateTime.Parse(date), cvv, fullname));

            exception.ShouldNotBeNull();
            exception.ShouldBeOfType<InvaildOwnerNameException>();
        }


        [Theory]
        [InlineData("5191914942157165", "2022-05-31", "123", "Magdalena Osetek")]
        public void Card_Should_Assign_Value_When_Is_Valid(string number, string date, string cvv, string fullname)
        {

            var card = new Card(number, DateTime.Parse(date), cvv, fullname);

            card.CardNumber.ShouldBe(number);
            card.ExpirationDate.ShouldBe(DateTime.Parse(date));
            card.Cvv.ShouldBe(cvv);
            card.FullName.ShouldBe(fullname);
        }
    }
}
