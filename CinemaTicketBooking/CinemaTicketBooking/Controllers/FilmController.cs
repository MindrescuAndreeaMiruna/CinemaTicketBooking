using CinemaTicketBooking.Data;
using CinemaTicketBooking.Models.DTOs;
using FilmTicketBooking.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace CinemaTicketBooking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilmController : ControllerBase
    {
        private Context _context;

        public FilmController(Context context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetClients()
        {
            return Ok(await _context.Films.ToListAsync());
        }

        [HttpGet("filmById/{id}")]
        public async Task<IActionResult> GetFilmsById([FromRoute] Guid id)
        {
            var filmById = _context.Films.FirstOrDefault(x => x.Id == id);
            return Ok(filmById);
        }

        [HttpPost("createFilm")]
        public async Task<IActionResult> CreateFilm(FilmDTO filmDTO)
        {
            var newFilm = new Film();
            newFilm.FilmName = filmDTO.FilmName;
            newFilm.DurationMinutes = filmDTO.DurationMinutes;
           

            await _context.AddAsync(newFilm);
            await _context.SaveChangesAsync();

            return Ok(newFilm);

        }
    }

   
}

