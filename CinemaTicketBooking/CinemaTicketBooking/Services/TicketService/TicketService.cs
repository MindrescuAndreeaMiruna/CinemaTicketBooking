using AutoMapper;
using CinemaTicketBooking.Models.DTOs;
using CinemaTicketBooking.Repositories;
using FilmTicketBooking.Models;

namespace CinemaTicketBooking.Services.TicketService
{
    public class TicketService : ITicketService
    {
        private readonly ITicketRepository _ticketRepository;
        private readonly IMapper _mapper;

        public TicketService(ITicketRepository ticketRepository, IMapper mapper)
        {
            _ticketRepository = ticketRepository;
            _mapper = mapper;
        }   

        public async Task<TicketDTO> GetTicketById(Guid id)
        {
            var ticket = _ticketRepository.GetTicketById(id);
            return _mapper.Map<TicketDTO>(ticket);

        }

        public async Task<TicketDTO> GetTicketByHallNumber(int hallNumber)
        {
            var ticket = _ticketRepository.GetTicketByHallNumber(hallNumber);
            return _mapper.Map<TicketDTO>(ticket);
        }

        public async Task CreateTicket(TicketDTO ticketDTO)
        {
            var ticket = _mapper.Map<Ticket>(ticketDTO);
            await _ticketRepository.CreateAsync(ticket);
            await _ticketRepository.SaveAsync();
        }

        public async Task<List<TicketDTO>> GetAllTickets()
        {
            var tickets = await _ticketRepository.GetAll();
            return _mapper.Map<List<TicketDTO>>(tickets);
        }

        public void DeleteTicket(Guid id)
        {
            var ticket = _ticketRepository.GetTicketById(id);
            _ticketRepository.Delete(ticket);
            _ticketRepository.Save();
        }
    }
}
