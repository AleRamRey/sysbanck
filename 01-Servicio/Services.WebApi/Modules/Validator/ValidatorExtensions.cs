using Microsoft.Extensions.DependencyInjection;
using Application.Validator;

namespace Services.WebApi.Modules.Validator
{
    public static class ValidatorExtensions
    {
        public static IServiceCollection AddValidator(this IServiceCollection services)
        {
            services.AddTransient<UsersDTOValidator>();
            return services;
        }
    }
}
