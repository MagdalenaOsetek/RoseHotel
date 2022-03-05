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
    //public class GuestTests
    //{
    //    [Fact]
    //    public void ChangeBlackList_Throws_InvaildBlackListStatusException_When_BlackListed_To_BlackedListed_From_BlackListed()
    //    {
    //        var guest = GetValidGuest();

    //        guest.ChangeBlackList(true);

    //        var exception = Record.Exception(() => guest.ChangeBlackList(true));

    //        exception.ShouldNotBeNull();

    //        exception.ShouldBeOfType<InvaildBlackListStatusException>();

    //    }


    //    [Fact]
    //    public void ChangeBlackList_Throws_InvaildBlackListStatusException_When_BlackListed_To_NotBlackedListed_From_NotBlackListed()
    //    {
    //        var guest = GetValidGuest();

    //        var exception = Record.Exception(() => guest.ChangeBlackList(false));

    //        exception.ShouldNotBeNull();

    //        exception.ShouldBeOfType<InvaildBlackListStatusException>();

    //    }


    //    [Fact]
    //    public void ChangeBlackList_Assigns_When_BlackListed_To_BlackedListed_From_NotBlackListed()
    //    {
    //        var guest = GetValidGuest();

    //        var exception = Record.Exception(() => guest.ChangeBlackList(true));

    //        exception.ShouldBeNull();

    //        guest.BlackListed.ShouldBe(true);

    //    }

    //    [Fact]
    //    public void ChangeBlackList_Assigns_When_BlackListed_To_NotBlackedListed_From_BlackListed()
    //    {
    //        var guest = GetValidGuest();

    //        guest.ChangeBlackList(true);

    //        var exception = Record.Exception(() => guest.ChangeBlackList(false));

    //        exception.ShouldBeNull();

    //        guest.BlackListed.ShouldBe(false);

    //    }



    //    public static  Guest GetValidGuest()
    //        => new Guest(Guid.NewGuid(), "Magdalena", "Osetek", DateTime.Now, "test@gmail.com",
    //            "+48693897274", new Card("5191914942157165", DateTime.Now.AddMonths(2), "123", "Magdalena Osetek"));
    //}
}
