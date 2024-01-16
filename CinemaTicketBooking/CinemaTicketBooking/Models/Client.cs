using System.ComponentModel.DataAnnotations;

namespace FilmTicketBooking.Models
{
    public class Client
    {
        [Required]
        public int Id { get; set; }

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




    }
}