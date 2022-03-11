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
        

        public string Street { get; private set; }
        public string City { get; private set; }
        public string Country { get; private set; }
        public string ZipCode { get; private set; }

        public Adress(string street, string city, string country, string zipCode)
        {
            var culutre = CultureInfo.GetCultures(CultureTypes.SpecificCultures).Select(x => (new RegionInfo(x.Name)).ToString()).ToList();

            if (string.IsNullOrEmpty(street) || street.Length>50)
            {
                throw new InvalidStreetException(street);
            }
            if ( string.IsNullOrEmpty(city) || !Regex.IsMatch(city, @"^[a-zA-Z][a-zA-Z\s-]+[a-zA-Z]$", RegexOptions.ECMAScript) || city.Length > 58 )
            {
                throw new InvalidCityException(city);
            }              
            if (!culutre.Contains(country))
            {
                throw new InvalidCountryException(country);
            }
            if (string.IsNullOrEmpty(zipCode) || !Regex.IsMatch(zipCode, @"^[0-9]{2,5}(?:-[0-9]{3,4})?$", RegexOptions.ECMAScript) )
            {
                throw new InvalidZipCodeException(zipCode);
            }



            Street = street;
            City = city;
            Country = country;
            ZipCode = zipCode;
        }

        //public static bool operator ==(Adress one, Adress two)
        //{
        //    if(one.City.Equals(two.City) && one.Country.Equals(two.Country) && one.Street.Equals(two.Street) && one.ZipCode.Equals(two.ZipCode))
        //    {
        //        return true;
        //    }

        //    return false;

        //}

        //public static bool operator !=(Adress one, Adress two)
        //{
        //    if (one.City.Equals(two.City) && one.Country.Equals(two.Country) && one.Street.Equals(two.Street) && one.ZipCode.Equals(two.ZipCode))
        //    {
        //        return false;
        //    }

        //    return true;

        //}
    }
}
