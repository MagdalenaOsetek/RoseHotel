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
            if (!Regex.IsMatch(cardNumber, @"(^4[0-9]{12}(?:[0-9]{3})?$)|(^(?:5[1-5][0-9]{2}|222[1-9]|22[3-9][0-9]|2[3-6][0-9]{2}|27[01][0-9]|2720)[0-9]{12}$)|(3[47][0-9]{13})|(^3(?:0[0-5]|[68][0-9])[0-9]{11}$)|(^6(?:011|5[0-9]{2})[0-9]{12}$)|(^(?:2131|1800|35\d{3})\d{11}$)", RegexOptions.ECMAScript) || string.IsNullOrEmpty(cardNumber))
            {
                throw new InvaildCardNumberException(cardNumber);
            }
            if(DateTime.UtcNow > expirationDate)
            {
                throw new CardExpiredException();
            }
            if(!Regex.IsMatch(cvv, @"^[0-9]{3,4}$", RegexOptions.ECMAScript) || string.IsNullOrEmpty(cvv))
            {
                
                    throw new InvaildCvvException(cvv);
            }
            if ( string.IsNullOrEmpty(fullName) || fullName.Length>100)
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
