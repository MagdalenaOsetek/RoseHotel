using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RoseHotel.Domain.Exceptions;

namespace RoseHotel.Domain.ValueObjects
{
    public class RoomType
    {
        public static readonly HashSet<string> AllowedValues = new()
        {
            "ECO",
            "STD",
            "LUX"
        };

        public string Value { get; }

        public RoomType(string value)
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

        public static implicit operator RoomType(string value) => value is null ? null : new RoomType(value);


        public static implicit operator string(RoomType value) => value?.Value;


    }
}
