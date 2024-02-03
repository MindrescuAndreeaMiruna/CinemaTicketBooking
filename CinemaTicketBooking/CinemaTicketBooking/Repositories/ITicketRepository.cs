using CinemaTicketBooking.Repositories.GenericRepository;
using FilmTicketBooking.Models;

namespace CinemaTicketBooking.Repositories
{
    public interface ITicketRepository : IGenericRepository<Ticket>
    {
        Ticket GetTicketById(Guid Id);
        Ticket GetTicketByHallNumber(int hallNumber);
        Ticket GetTicketBySeatAndRow(int seatNumber, int row); 
    }
}
