using CinemaTicketBooking.Data;
using FilmTicketBooking.Models;

namespace CinemaTicketBooking.Repositories
{
    public class TicketRepository : GenericRepository.GenericRepository<Ticket>, ITicketRepository
    {
        public TicketRepository(Context context) : base(context)
        {

        }

        public Ticket GetTicketById(Guid id)
        {
            return _context.Tickets.FirstOrDefault(x => x.Id == id);
        }

        public Ticket GetTicketByHallNumber(int hallNumber)
        {
            return _context.Tickets.FirstOrDefault(x => x.HallNumber == hallNumber);
        }

        public Ticket GetTicketBySeatAndRow( int seatNumber, int row)
        {
            return _context.Tickets.Where(a => a.Seat == seatNumber && a.Row == row).FirstOrDefault();
        }
    }
}
