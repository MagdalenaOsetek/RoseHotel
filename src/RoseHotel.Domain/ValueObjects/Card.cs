using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace RoseHotel.Domain.ValueObjects
{
    public class Card
    {
        public string CardNumber { get; }
        public string ExpirationDate { get; }
        public string CVV { get; }
        public string FullName { get; }

        public Card(string cardNumber, string expirationDate, string cvv, string fullName)
        {
            if (!Regex.IsMatch(CardNumber, @"/\d+/", RegexOptions.ECMAScript))
            {

            }

            CardNumber = cardNumber;
            ExpirationDate = expirationDate;
            CVV = cvv;
            FullName = fullName;
        }
    }
}
