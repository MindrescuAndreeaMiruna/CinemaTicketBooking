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
    public class TicketController : ControllerBase
    {
        private  Context _context;

        public TicketController(Context context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetClients()
        {
            return Ok(await _context.Clients.ToListAsync());
        }

        [HttpGet("ticketById/{id}")]
        public async Task<IActionResult> GetTicketsById([FromRoute] Guid id)
        {
            var ticketById = _context.Tickets.FirstOrDefault(x => x.Id == id);
            return Ok(ticketById);
        }
        [HttpPost("createTicket")]
        public async Task<IActionResult> CreateTicket(TicketDTO ticketDTO)
        {
            var newTicket = new Ticket();
            newTicket.HallNumber = ticketDTO.HallNumber;
            newTicket.Seat = ticketDTO.Seat;
            newTicket.Row = ticketDTO.Row;

            await _context.AddAsync(newTicket);
            await _context.SaveChangesAsync();

            return Ok(newTicket);
        }
    }
}

