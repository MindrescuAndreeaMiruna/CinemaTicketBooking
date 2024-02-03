using CinemaTicketBooking.Repositories.GenericRepository;
using FilmTicketBooking.Models;

namespace CinemaTicketBooking.Repositories
{
    public interface IFilmRepository : IGenericRepository<Film>
    {
        Film GetFilmById(Guid id);
        Film GetFilmByFilmName(string filmName);
        Film GetFilmByFilmNameAndDurationMinutes(string filmName, int durationMinutes);
    }
}
