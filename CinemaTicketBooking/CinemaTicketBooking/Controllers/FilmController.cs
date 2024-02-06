using CinemaTicketBooking.Data;
using CinemaTicketBooking.Models.DTOs;
using CinemaTicketBooking.Repositories;
using CinemaTicketBooking.Services.ClientService;
using CinemaTicketBooking.Services.FilmService;
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
        public readonly IFilmService _filmService;
        public readonly IFilmRepository _filmRepository;

        public FilmController(IFilmService filmService, IFilmRepository filmRepository)
        {
            _filmService = filmService;
            _filmRepository = filmRepository;
        }

        [HttpGet("GetFilmById")]
        public IActionResult GetFilmById([FromQuery] Guid id)
        {
            var film = _filmRepository.GetFilmById(id);
            if (film == null)
            {
                return NotFound();
            }
            return Ok(film);
        }

        [HttpGet("GetFilmByFilmName")]
        public IActionResult GetFilmByFilmName([FromQuery] string filmName)
        {
            var film = _filmService.GetFilmByFilmName(filmName);
            if (film == null)
            {
                return NotFound();
            }
            return Ok(film);
        }

        [HttpGet("GetAllFilms")]
        public async Task<IActionResult> GetAllFilms()
        {
            var films = await _filmService.GetAllFilms();
            return Ok(films);
        }

        [HttpDelete("DeleteFilm")]
        public IActionResult DeleteFilm([FromQuery] Guid id)
        {
            _filmService.DeleteFilm(id);
            return NoContent();
        }
    }

   
}

