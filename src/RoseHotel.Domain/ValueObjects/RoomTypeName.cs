using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RoseHotel.Domain.Exceptions;

namespace RoseHotel.Domain.ValueObjects
{
    public class RoomTypeName
    {
        public static readonly HashSet<string> AllowedValues = new()
        {
            "ECO",
            "STD",
            "LUX"
        };

        public string Value { get; }

        public RoomTypeName(string value)
        {
            if (string.IsNullOrWhiteSpace(value) || value.Length != 3)
            {
                throw new InvalidRoomTypeException(value);
            }

            value.ToUpperInvariant();

            if (!AllowedValues.Contains(value))
            {
                throw new UnsupportedRoomTypeException(value);
            }

            Value = value;
        }

        public static implicit operator RoomTypeName(string value) => value is null ? null : new RoomTypeName(value);


        public static implicit operator string(RoomTypeName value) => value?.Value;


    }
}
