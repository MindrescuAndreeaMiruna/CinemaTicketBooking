namespace CinemaTicketBooking.Models.DTOs
{
    public class UserResponseDTO
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string EmailUser { get; set; }

        public string FirstNameUser { get; set; }
        public string LastNameUser { get; set;}
        public string Token { get; set; }

        public UserResponseDTO(User user, string token)
        {
            Id = user.Id;
            FirstNameUser = user.FirstNameUser;
            LastNameUser = user.LastNameUser;
            EmailUser = user.EmailUser; 
            UserName = user.UserName;
            Token = token;
        }    


    }
}
