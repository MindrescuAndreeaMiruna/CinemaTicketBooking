using CinemaTicketBooking.Models;

namespace CinemaTicketBooking.Helper.JwtUtils
{
    public interface IJwtUtils
    {
        public string GenerateJwtToken(User user);
        public Guid ValidateJwtToken(string token);
       
    }
}
