using CinemaTicketBooking.Models.DTOs;

namespace CinemaTicketBooking.Services.UserService
{
    public interface IUserService
    {
        UserResponseDTO Authenticate(UserRequestDTO model);
        UserRequestDTO GetById(Guid id);
        Task Create(UserRequestDTO newUser);
    }
}
