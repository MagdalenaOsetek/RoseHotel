using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using RoseHotel.Domain.Exceptions;

namespace RoseHotel.Domain.ValueObjects
{
    public class Card
    {
        public string CardNumber { get; }
        public DateTime ExpirationDate { get; }
        public string CVV { get; }
        public string FullName { get; }

        public Card(string cardNumber, DateTime expirationDate, string cvv, string fullName)
        {
            if (!Regex.IsMatch(cardNumber, @"/^(?:4[0-9]{12}(?:[0-9]{3})?|[25][1-7][0-9]{14}|6(?:011|5[0-9][0-9])[0-9]{12}|3[47][0-9]{13}|3(?:0[0-5]|[68][0-9])[0-9]{11}|(?:2131|1800|35\d{3})\d{11})$/", RegexOptions.ECMAScript))
            {
                throw new InvaildCardNumberException(cardNumber);
            }
            if(DateTime.UtcNow > expirationDate)
            {
                throw new CardExpiredException();
            }
            if(cvv.Length!=3 || string.IsNullOrEmpty(cvv))
            {
                throw new InvaildCvvException(cvv);
            }
            if ( string.IsNullOrEmpty(fullName))
            {
                throw new InvaildOwnerNameException();
            }


            CardNumber = cardNumber;
            ExpirationDate = expirationDate;
            CVV = cvv;
            FullName = fullName;
        }
        public static bool operator == (Card one, Card two)
        {
            if(one.CardNumber.Equals(two.CardNumber) && one.ExpirationDate.Equals(two.ExpirationDate) && one.CVV.Equals(two.CVV) && one.FullName.Equals(two.FullName))
            {
                return true;
            }

            return false;
            
        }

        public static bool operator !=(Card one, Card two)
        {
            if (one.CardNumber.Equals(two.CardNumber) && one.ExpirationDate.Equals(two.ExpirationDate) && one.CVV.Equals(two.CVV) && one.FullName.Equals(two.FullName))
            {
                return false;
            }

            return true;

        }


    }
}
