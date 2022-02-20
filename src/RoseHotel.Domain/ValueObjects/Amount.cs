using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RoseHotel.Domain.Exceptions;

namespace RoseHotel.Domain.ValueObjects
{
    public class Amount 
    {
        public decimal Value { get; }

        public Amount(decimal value)
        {

            if (value is < 0 or > 100_000)
            {
                throw new InvalidAmountException(value);
            }
            this.Value = value;
        }

        public static implicit operator Amount(decimal value) => new(value);
        public static implicit operator decimal(Amount value) => value.Value;

        public static implicit operator Amount(Price value) => new(value);
        public static implicit operator Price(Amount value) => value.Value;
        public static Amount operator +(Amount a, Amount b) => a.Value + b.Value;
        public static Amount operator -(Amount a, Amount b) => a.Value - b.Value;
        public static Amount operator *(int a, Amount b) => a * b.Value;
        public static Amount operator /(Amount a, int b) => a.Value / b;
        public static bool operator <(Amount a, Amount b) => a.Value < b.Value;
        public static bool operator >(Amount a, Amount b) => a.Value > b.Value;
        public static bool operator <=(Amount a, Amount b) => a.Value <= b.Value;
        public static bool operator >=(Amount a, Amount b) => a.Value >= b.Value;
        public static bool operator == (Amount a, Amount b) => a.Value == b.Value;
        public static bool operator != (Amount a, Amount b) => a.Value != b.Value;


    }
}
