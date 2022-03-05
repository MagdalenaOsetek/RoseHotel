using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RoseHotel.Application.Abstractions;
using RoseHotel.Infrastructure.Commands;
using RoseHotel.Infrastructure.DAL;
using RoseHotel.Infrastructure.Queries;

namespace RoseHotel.Infrastructure
{
    public static class Extensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services,
        IConfiguration configuration)
        {
            //services.AddHttpClient();
            // services.AddHttpClient<IPaymentsApiClient, PaymentsApiClient>();

            services.AddSingleton<IDispatcher, InMemoryDispatcher>();
            services.AddSingleton<ICommandDispatcher, InMemoryCommandDispatcher>();
            services.AddSingleton<IQueryDispatcher, InMemoryQueryDispatcher>();
            // services.AddSingleton<IUserRepository, InMemoryUserRepository>();
            // services.AddSingleton<IWalletRepository, InMemoryWalletRepository>();
            // services.AddSingleton<ITransferRepository, InMemoryTransferRepository>();
            services.AddSingleton<IClock, Clock>();
            //services.AddScoped<ErrorHandlerMiddleware>();
            // services.AddScoped<LoggingMiddleware>();

            var lol = configuration.GetSection("database").Value;
            services.Configure<DatabaseSettings>(configuration.GetSection("database"));
            services.Configure<CacheSettings>(configuration.GetSection("cache"));
            services.Configure<ApiOptions>(configuration.GetSection("api"));


            services.AddDatabase(configuration);

            return services;
        }
    }
}
