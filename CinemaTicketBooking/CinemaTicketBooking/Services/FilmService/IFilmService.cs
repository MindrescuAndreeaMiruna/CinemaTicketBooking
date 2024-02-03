using CinemaTicketBooking.Models.DTOs;

namespace CinemaTicketBooking.Services.FilmService
{
    public interface IFilmService
    {
        Task CreateFilm(FilmDTO filmDTO);
        Task<FilmDTO> GetFilmById(Guid id);
        Task<FilmDTO> GetFilmByFilmName(string filmName);
        void DeleteFilm(Guid id);
        Task<List<FilmDTO>> GetAllFilms();
    }
}
