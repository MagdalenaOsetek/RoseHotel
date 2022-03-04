using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using RoseHotel.Application.Abstractions;
using RoseHotel.Application.Commands;
using RoseHotel.Application.Commands.Handlers;

namespace RoseHotel.Application
{
    public static class Extensions
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
          //  services.AddScoped<IUsersService, UsersService>();

            services.AddScoped<ICommandHandler<ChooseDateToBasket>, ChooseDateToBasketHandler>();
           // services.AddScoped<ICommandHandler<AddWallet>, AddWalletHandler>();
         //   services.AddScoped<ICommandHandler<DeleteWallet>, DeleteWalletHandler>();
           // services.AddScoped<ICommandHandler<TransferFunds>, TransferFundsHandler>();

           /// services.AddScoped<IQueryHandler<ChooseDateToBasket, IWalletDto>>, ChooseDateToBasketHandler>();
          //  services.AddScoped<IQueryHandler<GetWallet, WalletDetailsDto>, GetWalletHandler>();

            return services;
        }
    }
}
