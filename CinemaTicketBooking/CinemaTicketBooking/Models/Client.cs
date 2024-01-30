using CinemaTicketBooking.Models;
using CinemaTicketBooking.Models.Base;
using System.ComponentModel.DataAnnotations;

namespace FilmTicketBooking.Models
{
    public class Client : BaseEntity
    {

        [StringLength(50)]
        public string FirstName { get; set; }

        [StringLength(50)]

        public string LastName { get; set; }

        [Range(0, 50)]

        public int Age { get; set; }

        [StringLength(10)]

        public string? TelephoneNumber { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        public ICollection<RelatieClientFilm> RelatieClientFilms { get; set; }

        public Ticket Ticket { get; set; }
        public Guid TicketId { get; set; }


    }
}