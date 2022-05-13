using Microsoft.Extensions.DependencyInjection;
using Transversal.Common;
using Infraestructura.Data;
using Infraestructura.Repository;
using Application.Interface;
using Application.Main;
using Domain.Interface;
using Domain.Core;
using Infraestructura.Interface;
using Transversal.Logging;
using Microsoft.Extensions.Configuration;


namespace Services.WebApi.Modules.Injection
{
    public static class InjectionExtensions
    {
        public static IServiceCollection AddInjection(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IConfiguration>(configuration);
            services.AddSingleton<IConnectionFactory, ConnectionFactory>();
            services.AddScoped<ICustomersApplication, CustomersApplication>();
            services.AddScoped<ICustomersDomain, CustomersDomain>();
            services.AddScoped<ICustomersRepository, CustomersRepository>();
            services.AddScoped<IUsersApplication, UsersApplication>();
            services.AddScoped<IUsersDomain, UsersDomain>();
            services.AddScoped<IUsersRepository, UsersRepository>();
            services.AddScoped(typeof(IAppLogger<>), typeof(LoggerAdapter<>));

            return services;
        }

    }
}
