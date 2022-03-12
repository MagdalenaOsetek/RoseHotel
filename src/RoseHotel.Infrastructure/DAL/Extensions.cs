using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RoseHotel.Domain.Repositories;
using RoseHotel.Infrastructure.DAL.Repositories;

namespace RoseHotel.Infrastructure.DAL
{
    internal static class Extensions
    {
        public static IServiceCollection AddDatabase(this IServiceCollection services,IConfiguration configuration)
        {
            var lol = nameof(DatabaseSettings.ConnectionString);
            //var connectionString = configuration[$"database:{nameof(DatabaseSettings.ConnectionString)}"];
            var connectionString = configuration.GetSection("database").Value;
         //   var connectionString = configuration[$"database:Server = localhost; Port = 5432; Database = Hotel; User Id = admin; Password = admin1234"];

            services.AddDbContext<RoseHotelDbContext>(x => x.UseNpgsql(connectionString));


            var connectionString2 = configuration.GetSection("cache").Value;
            services.AddStackExchangeRedisCache(options =>
            {
                options.Configuration = connectionString2;

            });
            services.AddScoped<IBasketRepository, BasketRepository>();
            services.AddScoped<IRoomRepository, RoomRepository>();
            services.AddScoped<IRoomTypeRepository, RoomTypeRepository>();
            services.AddScoped<IReservationRepository, ReservationRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IGuestRepository, GuestRepository>();

            //services.AddHostedService<AppInitializer>();
            //services.AddHostedService<TransfersCalculatorBackgroundService>();

            return services;
        }
    }
}
