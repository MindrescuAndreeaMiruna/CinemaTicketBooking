using CinemaTicketBooking.Models;
using CinemaTicketBooking.Models.Base;
using System.ComponentModel.DataAnnotations;

namespace FilmTicketBooking.Models
{
    public class Film : BaseEntity
    {


        [Required]
        [MaxLength(100)]
        public string FilmName { get; set; }


        [Required]
        [MaxLength(3)]
        public int DurationMinutes {  get; set; }

        public ICollection<Ticket> Tickets { get; set; }
        public ICollection<RelatieClientFilm> RelatieClientFilms { get; set; }



    }
}