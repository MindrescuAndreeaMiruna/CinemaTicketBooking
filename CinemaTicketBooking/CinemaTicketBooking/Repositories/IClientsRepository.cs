using CinemaTicketBooking.Repositories.GenericRepository;
using FilmTicketBooking.Models;

namespace CinemaTicketBooking.Repositories
{
    public interface IClientsRepository : IGenericRepository<Client>
    {
        Client GetClientById(Guid id);
        Client GetClientByFirstName(string firstname);

        Client GetClientByAgeAndLastName(int age, string lastName);
  
    }
}
