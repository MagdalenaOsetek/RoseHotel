using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RoseHotel.Domain.ValueObjects;

namespace RoseHotel.Domain.Entities
{
    public class Guest
    {


        public Guid Id { get; private set; }
        public string Name { get; private set; }

        public string Surname { get; private set; }
        public Email Email { get; private set; }
        public PhoneNumber PhoneNumber { get; private set; }
        public Card Card { get; private set; }

        public Guest()
        {
        }

        public Guest(Guid id)
        {
            Id = id;

        }



        public static Guest Create(Guid guid) => new(guid);

    }
}
