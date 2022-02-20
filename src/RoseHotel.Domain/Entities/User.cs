using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RoseHotel.Domain.Exceptions;
using RoseHotel.Domain.ValueObjects;

namespace RoseHotel.Domain.Entities
{
    public class User
    {
        public Guid UserId { get; private set; }
        public Guest? Guest { get; private set; }
        public Email Email { get; private set; }
        public Password Password { get; private set; }
        public Role Role { get; set; }
        public string Token { get; set; }

        public DateTime CreatedAt { get; private set; }
        public DateTime? VerifiedAt { get; private set; }

        private User()
        {
        }

        public User(Guid userId, Email email, Password password, Role role,  DateTime createdAt, DateTime? verifiedAt)
        {
            UserId = userId;
          //  Guest = guest;
            Email = email;
            Password = password;
            Role = role;
            CreatedAt = createdAt;
            VerifiedAt = verifiedAt;
        }

        public bool IsVerified => VerifiedAt.HasValue;

        public void Verify(DateTime verifiedAt)
        {
            if (IsVerified)
            {
                throw new UserAlreadyVerifiedException(UserId);
            }

            VerifiedAt = verifiedAt;
        }
    }
}
