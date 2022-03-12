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


            services.AddScoped<ICommandHandler<AddRoomType>, AddRoomTypeHandler>();

            services.AddScoped<ICommandHandler<AddRoom>, AddRoomHandler>();

            services.AddScoped<ICommandHandler<ConfirmReservation>, ConfirmReservationHandler>();
            services.AddScoped<ICommandHandler<CancelReservation>, CancelReservationHandler>();
            services.AddScoped<ICommandHandler<PayReservation>, PayReservationHandler>();

            services.AddScoped<ICommandHandler<ChooseDateToBasket>, ChooseDateToBasketHandler>();
            services.AddScoped<ICommandHandler<AddGuestToBasket>, AddGuestToBasketHandler>();
            services.AddScoped<ICommandHandler<AddRoomToBasket>, AddRoomToBasketHandler>();

            services.AddScoped<ICommandHandler<RegisterUser>, RegisterUserHandler>();
            services.AddScoped<ICommandHandler<VerifyUser>, VerifyUserHandler>();
            services.AddScoped<ICommandHandler<UpsertGuestToUser>, UpsertGuestToUserHandler>();


            services.AddScoped<IQueryHandler<GetUser, UserDto>, GetUserHandler>();
            services.AddScoped<IQueryHandler<GetBasket, BasketDto>, GetBasketHandler>();
            services.AddScoped<IQueryHandler<BrowserUserReservations, IReadOnlyCollection<ReservationDto>>, BrowserUserReservationsHandler>();
            services.AddScoped<IQueryHandler<BrowserFreeRooms, IReadOnlyCollection<RoomTypeDto>>, BrowserFreeRoomsHandler>();
            services.AddScoped<IQueryHandler<BrowserRoomType, IReadOnlyCollection<RoomTypeDto>>, BrowserRoomTypeHandler>();
       

            return services;
        }
    }
}
