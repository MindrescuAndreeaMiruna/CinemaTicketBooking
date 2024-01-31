using CinemaTicketBooking.Data;
using FilmTicketBooking.Models;
using Microsoft.EntityFrameworkCore;

namespace CinemaTicketBooking.Repositories
{
    public class ClientRepository : GenericRepository.GenericRepository<Client>, IClientsRepository

    {
        public ClientRepository(Context context) : base(context)
        {

        }

        public Client GetClientById(Guid id)
        {
            return _context.Clients.FirstOrDefault(x => x.Id == id);
        }

       public Client GetClientByFirstName(string firstname)
        {
            return _context.Clients.FirstOrDefault(x => x.FirstName == firstname);
        }

        public  Client GetClientByAgeAndLastName(int age, string lastName)
        {
            return  _context.Clients.Where(a=> a.Age == age && a.LastName == lastName).FirstOrDefault();
        }


    }
}
