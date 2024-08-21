using Hangfire;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace TicketManagement.Core
{
    public static class ApplicationContainer
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
           
            return services;
        }
    }

}
