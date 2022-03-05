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
    //public class PasswordTests
    //{
    //    [Theory]
    //    [InlineData(null)]
    //    [InlineData("1234567")]
    //    [InlineData("abd1*2345678")]
    //    [InlineData("abdefghhJKID")]
    //    [InlineData("1234!56JKID")]
    //    public void Password_Should_Throw_InvalidPasswordException_When_Value_Is_Invalid(string password)
    //    {
    //        var exception = Record.Exception(() => new Password(password));

    //        exception.ShouldNotBeNull();
    //        exception.ShouldBeOfType<InvalidPasswordException>();
    //    }


    //    [Theory]
    //    [InlineData("123!jiIklwer")]
    //    [InlineData("abd1eeeF234567!8")]
    //    [InlineData("abdefg!hh22JKID")]
    //    [InlineData("ddd123ddd6J!KID")]
    //    public void Password_Should_Assign_Value_When_Is_Valid(string password)
    //    {
    //        var pass = new Password(password);

    //        pass.Value.ShouldBe(password);
    //    }


    //}
}
