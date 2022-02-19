using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RoseHotel.Domain.Exceptions;

namespace RoseHotel.Domain.ValueObjects
{
    public class Price
    {
        public decimal Value { get; }

        public Price(decimal value)
        {

            if (value is < 0 or > 1_000)
            {
                throw new InvalidPriceException(value);
            }
            this.Value = value;
        }

        public static implicit operator Price(decimal value) => new(value);
        public static implicit operator decimal(Price value) => value.Value;
        public static Price operator +(Price a, Price b) => a.Value + b.Value;
        public static Price operator -(Price a, Price b) => a.Value - b.Value;
        public static Price operator *(int a, Price b) => a * b.Value;
        public static Price operator /(Price a, int b) => a.Value / b;
        public static bool operator <(Price a, Price b) => a.Value < b.Value;
        public static bool operator >(Price a, Price b) => a.Value > b.Value;
        public static bool operator <=(Price a, Price b) => a.Value <= b.Value;
        public static bool operator >=(Price a, Price b) => a.Value >= b.Value;



    }
}
