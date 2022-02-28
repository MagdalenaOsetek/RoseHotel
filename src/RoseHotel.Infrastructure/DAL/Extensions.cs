using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace RoseHotel.Infrastructure.DAL
{
    internal static class Extensions
    {
        public static IServiceCollection AddDatabase(this IServiceCollection services,IConfiguration configuration)
        {
            var connectionString = configuration[$"database:Server = localhost; Port = 5432; Database = Hotel; User Id = admin; Password = admin1234"];
            services.AddDbContext<RoseHotelDbContext>(x => x.UseNpgsql(connectionString));
            services.AddStackExchangeRedisCache(options =>
            {
                options.Configuration = configuration.GetValue<string>("CacheSettings:ConnectionString");
            });
            //services.AddScoped<ITransferRepository, TransferRepository>();
            //services.AddScoped<IUserRepository, UserRepository>();
            //services.AddScoped<IWalletRepository, WalletRepository>();
            //services.AddHostedService<AppInitializer>();
            //services.AddHostedService<TransfersCalculatorBackgroundService>();

            return services;
        }
    }
}
