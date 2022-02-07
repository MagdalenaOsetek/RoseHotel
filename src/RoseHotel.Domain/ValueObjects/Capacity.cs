using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RoseHotel.Domain.Exceptions;

namespace RoseHotel.Domain.ValueObjects
{
    public class Capacity
    {
        public static readonly HashSet<int> AllowedValues = new()
        {
            1,
            2,
            3
        };

        public int Value { get; }

        public Capacity(int value)
        {
            if (!AllowedValues.Contains(value))
            {
                throw new UnsupportedCapacityException(value);
            }

            Value = value;
        }

        public static implicit operator Capacity(int value) => new(value);
        public static implicit operator int(Capacity value) => value.Value;

    }
}
