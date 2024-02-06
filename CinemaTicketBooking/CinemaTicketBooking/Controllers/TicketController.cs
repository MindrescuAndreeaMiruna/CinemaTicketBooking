using CinemaTicketBooking.Data;
using CinemaTicketBooking.Models.DTOs;
using CinemaTicketBooking.Repositories;
using CinemaTicketBooking.Services.FilmService;
using CinemaTicketBooking.Services.TicketService;
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
    public class TicketController : ControllerBase
    {
        public readonly ITicketService _ticketService;
        public readonly ITicketRepository _ticketRepository;

        public TicketController(ITicketService ticketService, ITicketRepository ticketRepository)
        {
            _ticketService = ticketService;
            _ticketRepository = ticketRepository;
        }



        [HttpGet("GetTicketById")]
        public IActionResult GetTicketById([FromQuery] Guid id)
        {
            var ticket = _ticketRepository.GetTicketById(id);
            if (ticket == null)
            {
                return NotFound();
            }
            return Ok(ticket);
        }

        [HttpGet("GetTicketByHallNumber")]
        public IActionResult GetTicketByHallNumber([FromQuery] int hallNumber)
        {
            var ticket = _ticketService.GetTicketByHallNumber(hallNumber);
            if (ticket == null)
            {
                return NotFound();
            }
            return Ok(ticket);
        }


        [HttpGet("GetAllTickets")]
        public async Task<IActionResult> GetAllTickets()
        {
            var tickets = await _ticketService.GetAllTickets();
            return Ok(tickets);
        }

        [HttpDelete("DeleteTicket")]
        public IActionResult DeleteTicket([FromQuery] Guid id)
        {
            _ticketService.DeleteTicket(id);
            return NoContent();
        }
    }
}

