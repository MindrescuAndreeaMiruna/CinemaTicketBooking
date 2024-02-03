using CinemaTicketBooking.Models.DTOs;

namespace CinemaTicketBooking.Services.TicketService
{
    public interface ITicketService
    {
        Task CreateTicket(TicketDTO ticketDTO);
        Task<TicketDTO> GetTicketById(Guid id);
        Task<TicketDTO> GetTicketByHallNumber(int hallNumber);
        void DeleteTicket(Guid id);
        Task<List<TicketDTO>> GetAllTickets();
    }
}
