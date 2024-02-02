using CinemaTicketBooking.Helper.JwtUtils;
using CinemaTicketBooking.Models.DTOs;
using CinemaTicketBooking.Repositories.UserRepository;
using BCryptNet = BCrypt.Net.BCrypt;

namespace CinemaTicketBooking.Services.UserService
{
    public class UserService : IUserService
    {
        public IUserRepository _userRepository;
        public IJwtUtils _jwtUtils;

        public UserService(IUserRepository userRepository, IJwtUtils jwtUtils)
        {
            _userRepository = userRepository;
            _jwtUtils = jwtUtils;
        }

        public UserResponseDTO Authenticate(UserRequestDTO model)
        {
            var user = _userRepository.FindByUserName(model.UserName);
            if (user == null || !BCryptNet.Verify(model.Password, user.PasswordHash)) 
            {
                return null;
            }

            var jwtToken = _jwtUtils.GenerateJwtToken(user);
            return new UserResponseDTO(user, jwtToken);
        }

        public Task Create(UserRequestDTO newUser)
        {
            throw new NotImplementedException();
        }

        public UserRequestDTO GetById(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
