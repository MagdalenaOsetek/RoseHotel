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
    public class UserTests
    {
        [Fact]
        public void Verify_Throws_UserAlreadyVerifiedException_When_User_Is_Already_Verified()
        {

            var user = GetValidUser();
            user.Verify(DateTime.Now);

            var exception = Record.Exception(() => user.Verify(DateTime.Now));

            exception.ShouldNotBeNull();
            exception.ShouldBeOfType<UserAlreadyVerifiedException>();
        }

        [Fact]
        public void Verify_Assigns_VerifiedAt_Date_If_No_Verification_Has_Been_Performed()
        {
            var user = GetValidUser();
            var verifyDate = DateTime.Now;

            var exception = Record.Exception(() => user.Verify(verifyDate));

            exception.ShouldBeNull();
            user.IsVerified.ShouldBeTrue();
        }

        public static Guest GetValidGuest()
           => new(Guid.NewGuid(), "Magdalena", "Osetek", DateTime.Now, "test@gmail.com",
               "+48693897274", new Adress("Klejowa", "Szczyrk", "PL", "91-402"), new Card("5191914942157165", DateTime.Now.AddMonths(2), "123", "Magdalena Osetek"));

        private static User GetValidUser()
            => new(Guid.NewGuid(), GetValidGuest(), "test@gmail.com", "1234567J!dhdee", "USER", null, DateTime.Now, null);
            
    }
}
