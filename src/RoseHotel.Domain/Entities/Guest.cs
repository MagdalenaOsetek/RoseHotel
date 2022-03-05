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
        public DateTime CreatedAt { get; private set; }
        public Email Email { get; private set; }
        public PhoneNumber PhoneNumber { get; private set; }
        public Adress Adress { get; private set; }

        public Card Card { get; private set; }

        public bool BlackListed { get; private set; } = false;

        public Guest()
        {
        }

        public Guest(Guid guestId, User user, ICollection<Reservation> reservations, string name, string surname, DateTime createdAt, Email email, PhoneNumber phoneNumber, Adress adress, Card card, bool blackListed)
        {
            GuestId = guestId;
            User = user;
            Reservations = reservations;
            Name = name;
            Surname = surname;
            CreatedAt = createdAt;
            Email = email;
            PhoneNumber = phoneNumber;
            Adress = adress;
            Card = card;
            BlackListed = blackListed;
        }

        public Guest( Guid guestId,string name, string surname,  DateTime createdAt, Email email, PhoneNumber phoneNumber, Adress adress) 
        {
            GuestId = guestId;
            Name = name;
            Surname = surname;
            CreatedAt = createdAt;
            Email = email;
            PhoneNumber = phoneNumber;
            Adress = adress;
            
        }


        public bool IsBlackListed () => BlackListed;


        public void ChangeBlackList(bool status)
        {
            if((status== true && BlackListed==true) || (status == false && BlackListed == false))
            {
                throw new InvaildBlackListStatusException(Name+ " "+ Surname);
            }

            BlackListed = status;
        }

        public void AddCard( string cardNumber , DateTime expirationDate , string cvv, string fullName)
        {
            Card = new Card(cardNumber, expirationDate, cvv, fullName);
        }
    }
}
