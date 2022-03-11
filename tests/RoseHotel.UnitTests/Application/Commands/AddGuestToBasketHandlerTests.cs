using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NSubstitute;
using RoseHotel.Application.Abstractions;
using RoseHotel.Application.Commands;
using RoseHotel.Application.Commands.Handlers;
using RoseHotel.Application.Exceptions;
using RoseHotel.Domain.Entities;
using RoseHotel.Domain.Repositories;
using RoseHotel.Domain.ValueObjects;
using Shouldly;
using Xunit;

namespace RoseHotel.UnitTests.Application.Commands
{
    public class AddGuestToBasketHandlerTests
    {

        [Fact]
        public async Task HandleAsync_Throws_BasketNotFoundException_When_Basket_With_Given_Id_IsNot_Found()
        {
            var command = new AddGuestToBasket(basketId, "Magdalena", "Osetek", "693897274", "test@gmail.com",
                "Klejowa", "Szczyrk", "PL", "91-402");

            _basketRepository.GetAsync(command.BasketId).Returns(default(Basket));

            var exception = await Record.ExceptionAsync(() => _handler.HandleAsync(command));

            exception.ShouldNotBeNull();
            exception.ShouldBeOfType<BasketNotFoundException> ();

        }


        [Theory]
        [InlineData("Magdalena", "Osetek", "693897274", "test@gmail.com","Klejowa", "Szczyrk", "PL", "91-402")]
        public async Task HandleAsync_Calls_Repository_On_Success(string name, string surname, string number, string email, string adress, string city, string country, string code)
        {
            var command = new AddGuestToBasket(basketId, name, surname, number, email, adress, city, country, code);

           
            _basketRepository.GetAsync(command.BasketId).Returns(GetValidBasket());

            var exception = await Record.ExceptionAsync(() => _handler.HandleAsync(command));

            exception.ShouldBeNull();

            await _basketRepository.Received(1).UpdateAsync(Arg.Is<Basket>(x => 
            x.Name==name && x.Surname ==surname && x.PhoneNumber==number && x.Email == email && x.Adress.Street == adress && x.Adress.City == city && x.Adress.Country == country && x.Adress.ZipCode== code ));

        }



        private readonly ICommandHandler<AddGuestToBasket> _handler;
        private readonly IBasketRepository _basketRepository;


        public AddGuestToBasketHandlerTests()
        {
            _basketRepository = Substitute.For<IBasketRepository>();
            _handler = new AddGuestToBasketHandler(_basketRepository);
        }

        public static Guid basketId = Guid.NewGuid();

        public static Basket GetValidBasket() => new Basket(basketId, DateTime.Today.AddDays(3), DateTime.Today.AddDays(5), new List<Capacity> { 2 }, DateTime.Now);

  
    }
}
