using System.ComponentModel.DataAnnotations;

namespace CinemaTicketBooking.Models.DTOs
{
    public class UserRequestDTO
    {

        [Required]   
        public string UserName { get; set; }
        [Required]

        public string Password { get; set; }
        [Required]

        public string EmailUser { get; set; }
        public string FirstNameUser { get; set; }
        public string LastNameUser { get; set;}
    }
}
