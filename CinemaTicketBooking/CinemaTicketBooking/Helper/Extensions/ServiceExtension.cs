using CinemaTicketBooking.Repositories;
using CinemaTicketBooking.Services.ClientService;
using Microsoft.Extensions.DependencyInjection;

namespace CinemaTicketBooking.Helper.Extensions
{
    public static class ServiceExtension
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddTransient<IClientsRepository, ClientRepository>();
            return services;
        }

        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddTransient<IClientService, ClientService>();
            return services;
        }
    }
}
