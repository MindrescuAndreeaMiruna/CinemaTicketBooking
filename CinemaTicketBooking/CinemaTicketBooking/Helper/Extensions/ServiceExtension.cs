using CinemaTicketBooking.Helper.JwtUtils;
using CinemaTicketBooking.Helper.Seeders;
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

        public static IServiceCollection AddSeeders(this IServiceCollection services)
        {
            services.AddScoped<ClientSeeder>();
            return services;
        }

        public static IServiceCollection AddUtils(this IServiceCollection services)
        {
            services.AddScoped<IJwtUtils, JwtUtils.JwtUtils>();
            return services;
        }
    }
}
