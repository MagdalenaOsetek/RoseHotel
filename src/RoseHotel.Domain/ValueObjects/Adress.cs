using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using RoseHotel.Domain.Exceptions;

namespace RoseHotel.Domain.ValueObjects
{
    public class Adress
    {
        

        public string Street { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string ZipCode { get; set; }

        public Adress(string street, string city, string country, string zipCode)
        {
            var culutre = CultureInfo.GetCultures(CultureTypes.AllCultures).Select(x => x.EnglishName).ToList();

            if (string.IsNullOrEmpty(street) || street.Length>50)
            {
                throw new InvalidStreetException(street);
            }
            if (!Regex.IsMatch(city, @"^[a-zA-Z][a-zA-Z\s-]+[a-zA-Z]$", RegexOptions.ECMAScript) || city.Length > 59 || string.IsNullOrEmpty(city))
            {
                throw new InvalidCityException(city);
            }              
            if (!culutre.Contains(country))
            {
                throw new InvalidCountryException(country);
            }
            if (!Regex.IsMatch(zipCode, @"^[0 - 9]{ 5} (?: -[0 - 9]{ 4})?$", RegexOptions.ECMAScript) || string.IsNullOrEmpty(zipCode))
            {
                throw new InvalidZipCodeException(zipCode);
            }



            Street = street;
            City = city;
            Country = country;
            ZipCode = zipCode;
        }

        public static bool operator ==(Adress one, Adress two)
        {
            if(one.City.Equals(two.City) && one.Country.Equals(two.Country) && one.Street.Equals(two.Street) && one.ZipCode.Equals(two.ZipCode))
            {
                return true;
            }

            return false;

        }

        public static bool operator !=(Adress one, Adress two)
        {
            if (one.City.Equals(two.City) && one.Country.Equals(two.Country) && one.Street.Equals(two.Street) && one.ZipCode.Equals(two.ZipCode))
            {
                return false;
            }

            return true;

        }
    }
}
