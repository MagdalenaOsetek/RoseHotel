using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
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

            var appSettingsSection = configuration.GetSection("AppSettings");
            services.Configure<AppSettings>(appSettingsSection);
            services.Configure<DatabaseSettings>(configuration.GetSection("database"));
            services.Configure<CacheSettings>(configuration.GetSection("cache"));
            services.Configure<ApiOptions>(configuration.GetSection("api"));

            

            var appSettings = appSettingsSection.Get<AppSettings>();
            var key = Encoding.ASCII.GetBytes(appSettings.Secret);


            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x => {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });


            services.AddCors();
            services.AddDatabase(configuration);

            return services;
        }
    }
}
