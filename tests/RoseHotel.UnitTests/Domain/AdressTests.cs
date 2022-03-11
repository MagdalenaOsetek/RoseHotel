using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RoseHotel.Domain.Exceptions;
using RoseHotel.Domain.ValueObjects;
using Shouldly;
using Xunit;

namespace RoseHotel.UnitTests.Domain
{
    public class AdressTests
    {

        [Theory]
        [InlineData(null, "Lodz", "PL", "91-402")]
        public void Adress_Should_Throw_InvalidStreetException_When_Street_Is_Invalid(string street, string city, string country, string zipCode)
        {
            var exception = Record.Exception(() => new Adress(street, city, country, zipCode));

            exception.ShouldNotBeNull();
            exception.ShouldBeOfType<InvalidStreetException>();
        }


        [Theory]
        [InlineData("Matejki 4", null, "PL", "91---402")]
        [InlineData("Tamka 12", "Llanfairpwllgwyngyllgogerychwyrndrobwllllantysiliogogogocht", "GB", "91-402")]
        [InlineData("Sienkiewicza", "L0dz", "PL", "91-402")]
        [InlineData("Matejki 4", "L0dz!", "PL", "91-402")]
        public void Adress_Should_Throw_InvalidCityException_When_City_Is_Invalid(string street, string city, string country, string zipCode)
        {
            var exception = Record.Exception(() => new Adress(street, city, country, zipCode));

            exception.ShouldNotBeNull();
            exception.ShouldBeOfType<InvalidCityException>();
        }



        [Theory]
        [InlineData("Matejki 4", "Lodz", "Polska", "91-402")]
        [InlineData("Lon Toy Crose 4", "Llanfairpwllgwyngyllgogerychwyrndrobwllllantysiliogogogoch", "GB!", "91-402")]
        [InlineData("Wall Street 1", "New York", "USA", "91-402")]
        public void Adress_Should_Throw_InvalidCountryException_When_City_Is_Invalid(string street, string city, string country, string zipCode)
        {
            var exception = Record.Exception(() => new Adress(street, city, country, zipCode));

            exception.ShouldNotBeNull();
            exception.ShouldBeOfType<InvalidCountryException>();
        }



        [Theory]
        [InlineData("Matejki 4", "Lodz", "PL", "91---402")]
        [InlineData("Lon Toy Crose 4", "Llanfairpwllgwyngyllgogerychwyrndrobwllllantysiliogogogoch", "GB", "531!!!83")]
        [InlineData("Wall Street 1", "New York", "US", null)]
        public void Adress_Should_Throw_InvalidZipCodeException_When_City_Is_Invalid(string street, string city, string country, string zipCode)
        {
            var exception = Record.Exception(() => new Adress(street, city, country, zipCode));

            exception.ShouldNotBeNull();
            exception.ShouldBeOfType<InvalidZipCodeException>();
        }



        [Theory]
        [InlineData("Matejki 4", "Lodz", "PL", "91-402")]
        [InlineData("Lon Toy Crose 4", "Llanfairpwllgwyngyllgogerychwyrndrobwllllantysiliogogogoch", "GB", "53183")]
        [InlineData("Wall Street 1", "New York", "US", "10001-4774")]
        public void Adress_Should_Assign_Values_When_Is_Valid(string street, string city, string country, string zipCode)
        {

            var adress = new Adress(street, city, country, zipCode);

            adress.Street.ShouldBe(street);
            adress.City.ShouldBe(city);
            adress.Country.ShouldBe(country);
            adress.ZipCode.ShouldBe(zipCode);
        }
    }
}
