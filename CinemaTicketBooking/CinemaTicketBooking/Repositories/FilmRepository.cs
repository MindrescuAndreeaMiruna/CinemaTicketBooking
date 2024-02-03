using CinemaTicketBooking.Data;
using CinemaTicketBooking.Repositories.GenericRepository;
using FilmTicketBooking.Models;

namespace CinemaTicketBooking.Repositories
{
    public class FilmRepository : GenericRepository<Film>, IFilmRepository
    {
        public FilmRepository(Context context) : base(context)
        {

        }

        public Film GetFilmById(Guid id)
        {
            return _context.Films.FirstOrDefault(x => x.Id == id);
        }

        public Film GetFilmByFilmName(string filmName)
        {
            return _context.Films.FirstOrDefault(x => x.FilmName == filmName);
        }

        public Film GetFilmByFilmNameAndDurationMinutes(string filmName, int durationMinutes)
        {
            return _context.Films.Where(a => a.FilmName == filmName && a.DurationMinutes == durationMinutes).FirstOrDefault();
        }
    }
}
