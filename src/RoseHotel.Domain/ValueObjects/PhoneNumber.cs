using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using RoseHotel.Domain.Exceptions;

namespace RoseHotel.Domain.ValueObjects
{
    public class PhoneNumber
    {
        public string Value { get; }

        public PhoneNumber(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new InvalidPhoneNumberException(value);
            }
            if (!Regex.IsMatch(value, @"\+?[\s]?[0-9]?[0-9]?[0-9]?[\s-]?[0-9][0-9][0-9][\s-]?[0-9][0-9][0-9][\s-]?[0-9][0-9][0-9]$", RegexOptions.ECMAScript))
            {
                throw new InvalidPhoneNumberException(value);
            }

            Value = value;
        }

        public static implicit operator PhoneNumber(string value) => value is null ? null : new PhoneNumber(value);
        public static implicit operator string(PhoneNumber value) => value.Value;

    }
}
