using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RoseHotel.Domain.Exceptions;

namespace RoseHotel.Domain.ValueObjects
{
    public class Role
    {
        public static readonly HashSet<string> AllowedValues = new()
        {
            "USER",
            "ADMIN"

        };

        public string Value { get; }

        public Role(string value)
        {

            value.ToUpperInvariant();

            if (!AllowedValues.Contains(value))
            {
                throw new UnsupportedRoleException(value);
            }

            Value = value;
        }

        public static implicit operator Role(string value) => value is null ? null : new Role(value);


        public static implicit operator string(Role value) => value?.Value;
    }
}
