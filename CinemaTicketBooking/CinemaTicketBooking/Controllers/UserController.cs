using CinemaTicketBooking.Data;
using CinemaTicketBooking.Models;
using CinemaTicketBooking.Models.DTOs;
using CinemaTicketBooking.Services.UserService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BCryptNet = BCrypt.Net.BCrypt;

namespace CinemaTicketBooking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly Context _context;

        public UserController(IUserService userService, Context context)
        {
            _userService = userService;
            _context = context;
        }

        [HttpPost("createUser")]
        public async Task<IActionResult> CreateUser(UserRequestDTO userRequestDTO)
        {
            var userToCreate = new User
            {
                UserName = userRequestDTO.UserName,
                FirstNameUser = userRequestDTO.FirstNameUser,
                EmailUser = userRequestDTO.EmailUser,
                PasswordHash = BCryptNet.HashPassword(userRequestDTO.Password),
                Role = Models.Enums.Role.User
            };
            if(await _context.Users.AnyAsync(x=>x.UserName == userToCreate.UserName))
            {
                return BadRequest("Username already in use.");
            }

            await _userService.Create(userRequestDTO);
            return Ok();
        }

        [HttpPost("createAdmin")]
        public async Task<IActionResult> CreateAdmin(UserRequestDTO userRequestDTO)
        {
            var userToCreate = new User
            {
                UserName = userRequestDTO.UserName,
                FirstNameUser = userRequestDTO.FirstNameUser,
                LastNameUser = userRequestDTO.LastNameUser,
                EmailUser = userRequestDTO.EmailUser,
                PasswordHash = userRequestDTO.Password,
                Role = Models.Enums.Role.Admin
            };

            if (await _context.Users.AnyAsync(x=>x.UserName == userToCreate.UserName))
            {
                return BadRequest("Username already in use.");
            }
            await _userService.Create(userRequestDTO);  
            return Ok();
        }

        [HttpPost("authenticate")]

        public async Task<IActionResult> Authenticate(UserRequestDTO userRequestDTO)
        {
            var response = _userService.Authenticate(userRequestDTO);
            if (response == null)
            {
                return BadRequest("Username or password is invalid!");
            }
            return Ok(response);
        }

    }
}
