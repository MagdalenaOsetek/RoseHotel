using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RoseHotel.Domain.Exceptions;

namespace RoseHotel.Domain.ValueObjects
{
    public class Email
    {
        public string Value { get; }

        public Email(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new InvalidEmailException(value);
            }
            if (!new EmailAddressAttribute().IsValid(value))
            {
                throw new InvalidEmailException(value);
            }

            Value = value;
        }

        public static implicit operator Email(string value) => new(value);

        public static implicit operator string(Email email) => email.Value;
    }
}
