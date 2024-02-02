using AutoMapper;
using CinemaTicketBooking.Models.DTOs;
using FilmTicketBooking.Models;

namespace CinemaTicketBooking.Helper.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile() 
        {
            CreateMap<Client, ClientDTO>();
            CreateMap<ClientDTO, Client>();
            CreateMap<Film, FilmDTO>();
            CreateMap<FilmDTO, Film>();
            CreateMap<Ticket, TicketDTO>();
            CreateMap<TicketDTO, Ticket>();


        }
    }
}
