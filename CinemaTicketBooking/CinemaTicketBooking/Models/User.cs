using CinemaTicketBooking.Models.Base;
using Microsoft.AspNetCore.Identity;
using System.Text.Json.Serialization;
using CinemaTicketBooking.Models.Enums;

namespace CinemaTicketBooking.Models
{
    public class User : BaseEntity
    {
        public string FirstNameUser { get; set; }
        public string LastNameUser { get; set; }
        public string EmailUser { get; set; }
        public string UserName { get; set; }
        [JsonIgnore]
        public string PasswordHash { get; set; }
        public Role Role { get; set; }
    }
    
}
