using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RoseHotel.Domain.Exceptions;
using RoseHotel.Domain.ValueObjects;

namespace RoseHotel.Domain.Entities
{
    public class Guest
    {


        public Guid GuestId { get; private set; }
        public User? User { get; private set; }
        public ICollection<Reservation> Reservations { get; private set; }

        public string Name { get; private set; }
        public string Surname { get; private set; }
        public string Nationality { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public Email Email { get; private set; }
        public PhoneNumber PhoneNumber { get; private set; }
        public Card Card { get; private set; }

        public bool BlackListed { get; private set; }

        public Guest()
        {
        }

        public Guest(Guid id)
        {
            GuestId = id;

        }

        public Guest(Guid guestId, string name, string surname, string nationality, DateTime createdAt, Email email, PhoneNumber phoneNumber, Card card) : this(guestId)
        {
            Name = name;
            Surname = surname;
            Nationality = nationality;
            CreatedAt = createdAt;
            Email = email;
            PhoneNumber = phoneNumber;
            Card = card;
        }

        public static Guest Create(Guid guid) => new(guid);


        public void ChangeBlackList(bool status)
        {
            if((status== true && BlackListed==true) || (status == false && BlackListed == false))
            {
                throw new InvaildBlackListStatusException(Name+ " "+ Surname);
            }

            BlackListed = status;
        }
    }
}
