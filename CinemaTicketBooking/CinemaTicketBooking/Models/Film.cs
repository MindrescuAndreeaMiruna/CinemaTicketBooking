using CinemaTicketBooking.Models.Base;
using System.ComponentModel.DataAnnotations;

namespace FilmTicketBooking.Models
{
    public class Film : BaseEntity
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string FilmName { get; set; }


        [Required]
        [MaxLength(3)]
        public int DurationMinutes {  get; set; }



    }
}