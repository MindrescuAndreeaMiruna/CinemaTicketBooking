using CinemaTicketBooking.Data;
using FilmTicketBooking.Models;

namespace CinemaTicketBooking.Helper.Seeders
{
    public class TicketSeeder
    {

        public readonly Context _context;

        public TicketSeeder(Context context)
        {
            _context = context;
        }

        public void SeedInitialTicket()
        {
            if (!_context.Tickets.Any())
            {
                var film1 = _context.Films.First();
                var ticket1 = new Ticket
                {
                    HallNumber = 2,
                    Seat = 5,
                    Row = 8,
                    HourAndMinute = "12:45",
                    Film = film1
                };

                var film2 = _context.Films.Skip(1).FirstOrDefault();
                var ticket2 = new Ticket
                {
                    HallNumber = 4,
                    Seat = 7,
                    Row = 9,
                    HourAndMinute = "21:08",
                    Film = film2
                };

                _context.Tickets.Add(ticket1);
                _context.Tickets.Add(ticket2);

                _context.SaveChanges();

            }
        }

    }
}
