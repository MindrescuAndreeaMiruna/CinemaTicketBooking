using CinemaTicketBooking.Helper.JwtUtils;
using CinemaTicketBooking.Helper.Seeders;
using CinemaTicketBooking.Repositories;
using CinemaTicketBooking.Services.ClientService;
using CinemaTicketBooking.Services.FilmService;
using CinemaTicketBooking.Services.TicketService;
using Microsoft.Extensions.DependencyInjection;

namespace CinemaTicketBooking.Helper.Extensions
{
    public static class ServiceExtension
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddTransient<IFilmRepository, FilmRepository>();
            services.AddTransient<ITicketRepository, TicketRepository>();
            services.AddTransient<IClientsRepository, ClientRepository>();

            return services;
        }

        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddTransient<IFilmService, FilmService>();
            services.AddTransient<ITicketService, TicketService>();
            services.AddTransient<IClientService, ClientService>();


            return services;
        }

        public static IServiceCollection AddSeeders(this IServiceCollection services)
        {
            services.AddScoped<FilmSeeder>();
            services.AddScoped<TicketSeeder>();
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
