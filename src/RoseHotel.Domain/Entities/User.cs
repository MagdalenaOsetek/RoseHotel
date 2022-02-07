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
        public Guid Id { get; private set; }
        public Guid GuestId { get; private set; }
        public Email Email { get; private set; }
        public Password Password { get; private set; }
        public string Nationality { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime? VerifiedAt { get; private set; }

        private User()
        {
        }

        public User(Guid id, Guid guestId, Email email, Password password, DateTime createdAt)
        {
            Id = id;
            GuestId = guestId;
            Email = email;
            Password = password;
            CreatedAt = createdAt;
        }

        public static User Create( Email email, Password password, DateTime createdAt )
        {
            var guid = Guid.NewGuid();
            Guest.Create(guid);
            return new(Guid.NewGuid(), guid, email, password, createdAt);
        }

        public bool IsVerified => VerifiedAt.HasValue;

        public void Verify(DateTime verifiedAt)
        {
            if (IsVerified)
            {
                throw new UserAlreadyVerifiedException(Id);
            }

            VerifiedAt = verifiedAt;
        }
    }
}
