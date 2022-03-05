using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RoseHotel.Domain.Exceptions;
using RoseHotel.Domain.ValueObjects;
using Shouldly;
using Xunit;

namespace RoseHotel.UnitTests.Domain
{
    //public class PhoneNumberTests
    //{
    //    [Theory]
    //    [InlineData("")]
    //    [InlineData("1234")]
    //    [InlineData("12444ddd34")]
    //    public void PhoneNumber_Should_Thorw_InvalidPhoneNumberException_When_Value_Is_Invalid(string value)
    //    {
    //        var exception = Record.Exception(() => new PhoneNumber(value));

    //        exception.ShouldNotBeNull();
    //        exception.ShouldBeOfType<InvalidPhoneNumberException>();
    //    }

    //    [Theory]
    //    [InlineData("693897274")]
    //    [InlineData("+6179989234")]
    //    [InlineData("+48612345678")]
    //    public void PhoneNumber_Should_Assign_Value_When_Is_Valid(string value)
    //    {
    //        var pass = new PhoneNumber(value);

    //        pass.Value.ShouldBe(value);
    //    }
    //}
}
