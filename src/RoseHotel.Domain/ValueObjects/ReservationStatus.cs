using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RoseHotel.Domain.Exceptions;

namespace RoseHotel.Domain.ValueObjects
{
    public class ReservationStatus
    {
        public static readonly HashSet<string> AllowedValues = new()
        {
            "UNVERIFY",
            "VERIFY",
            "PAID",
            "CHECKED IN",
            "CHECKED OUT",
            "CANCEL"
        };

        public string Value { get; }

        public ReservationStatus(string value)
        {

            value.ToUpperInvariant();

            if (!AllowedValues.Contains(value))
            {
                throw new UnsupportedReservationStatusException(value);
            }

            Value = value;
        }

        public static implicit operator ReservationStatus(string value) => value is null ? null : new ReservationStatus(value);


        public static implicit operator string(ReservationStatus value) => value?.Value;
    }
}
