
using Microsoft.Extensions.DependencyInjection;
using FluentValidation;

namespace ERP.Application.Shared
{
    public static class ApplicationServiceRegistration
    {
        public static void AddApplicationServiceRegistration(this IServiceCollection services)
        {
            services.AddValidatorsFromAssembly(typeof(ApplicationServiceRegistration).Assembly);
        }
    }
}
