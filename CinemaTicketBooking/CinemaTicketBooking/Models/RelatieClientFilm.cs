using FilmTicketBooking.Models;

namespace CinemaTicketBooking.Models
{
    public class RelatieClientFilm
    {
        public Guid ClientId { get; set; }
        public Client Client { get; set; }
        public Guid FilmId { get; set; }
        public Film Film { get; set; }
    }
}
