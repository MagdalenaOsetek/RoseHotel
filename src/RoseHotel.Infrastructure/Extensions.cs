using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RoseHotel.Application.Abstractions;
using RoseHotel.Infrastructure.DAL;


namespace RoseHotel.Infrastructure
{
    public static class Extensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services,
        IConfiguration configuration)
        {
            //services.AddHttpClient();
            // services.AddHttpClient<IPaymentsApiClient, PaymentsApiClient>();

            //services.AddSingleton<IDispatcher, InMemoryDispatcher>();
            // services.AddSingleton<ICommandDispatcher, InMemoryCommandDispatcher>();
            // services.AddSingleton<IQueryDispatcher, InMemoryQueryDispatcher>();
            // services.AddSingleton<IUserRepository, InMemoryUserRepository>();
            // services.AddSingleton<IWalletRepository, InMemoryWalletRepository>();
            // services.AddSingleton<ITransferRepository, InMemoryTransferRepository>();
            services.AddSingleton<IClock, Clock>();
            //services.AddScoped<ErrorHandlerMiddleware>();
            // services.AddScoped<LoggingMiddleware>();

            //services.Configure<ApiOptions>(configuration.GetSection("api"));
            //database = configuration.GetSection("database");
            //services.Configure<DatabaseSettings>(database);
            //services.Configure<DatabaseSettings>("lol");
            //services.Configure<CacheSettings>(configuration.GetSection("cache").action);
            //services.Configure<ApiOptions>(configuration.GetSection("api"));


            services.AddDatabase(configuration);

            return services;
        }
    }
}
