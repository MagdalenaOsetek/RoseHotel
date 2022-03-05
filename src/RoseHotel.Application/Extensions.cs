using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using RoseHotel.Application.Abstractions;
using RoseHotel.Application.Commands;
using RoseHotel.Application.Commands.Handlers;
using RoseHotel.Application.DTO;
using RoseHotel.Application.Queries;
using RoseHotel.Application.Queries.Handlers;

namespace RoseHotel.Application
{
    public static class Extensions
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
          //  services.AddScoped<IUsersService, UsersService>();

            services.AddScoped<ICommandHandler<ChooseDateToBasket>, ChooseDateToBasketHandler>();
            services.AddScoped<ICommandHandler<RegisterUser>, RegisterUserHandler>();

            services.AddScoped<ICommandHandler<VerifyUser>, VerifyUserHandler>();
            services.AddScoped<ICommandHandler<AddGuestToUser>, AddGuestToUserHandler>();
            // services.AddScoped<ICommandHandler<ChooseDateToBasket>, ChooseDateToBasketHandler>();
            // services.AddScoped<ICommandHandler<AddWallet>, AddWalletHandler>();
            //   services.AddScoped<ICommandHandler<DeleteWallet>, DeleteWalletHandler>();
            // services.AddScoped<ICommandHandler<TransferFunds>, TransferFundsHandler>();

            //services.AddScoped<ICommandHandler<GetUser>, GetUserHandler>();
            services.AddScoped<IQueryHandler<GetUser, UserDto>, GetUserHandler>();
            //  services.AddScoped<IQueryHandler<GetWallet, WalletDetailsDto>, GetWalletHandler>();

            return services;
        }
    }
}
