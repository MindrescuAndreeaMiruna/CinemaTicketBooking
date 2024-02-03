using CinemaTicketBooking.Data;
using FilmTicketBooking.Models;

namespace CinemaTicketBooking.Helper.Seeders
{
    public class FilmSeeder
    {
        public readonly Context _context;

        public FilmSeeder(Context context)
        {
            _context = context;
        }

        public void SeedInitialFilm()
        {
            if (!_context.Films.Any())
            {
                var film1 = new Film
                {
                    FilmName = "Barbie",
                    DurationMinutes = 120
                };

                var film2 = new Film
                {
                    FilmName = "Aquaman",
                    DurationMinutes = 134
              
                };

                _context.Films.Add(film1);
                _context.Films.Add(film2);

                _context.SaveChanges();
            }

            

        }
    }
}
