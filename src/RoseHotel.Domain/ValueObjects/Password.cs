using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using RoseHotel.Domain.Exceptions;

namespace RoseHotel.Domain.ValueObjects
{
    //hasło musi miec wiecej niz 8 znakow mniej niz 22 i zaiwrac cyfre oraz male i duze litery
    public class Password
    {
        public string Value { get; }


        public Password(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new InvalidPasswordException();
            }


            if (!Regex.IsMatch(value, @"^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$ %^&*-]).{8,}$", RegexOptions.ECMAScript))
            {
                throw new InvalidPasswordException();
            }
            Value = value;

        }

        public static implicit operator Password(string value) => new Password(value);
        public static implicit operator string(Password value) => value.Value;
    }
}
