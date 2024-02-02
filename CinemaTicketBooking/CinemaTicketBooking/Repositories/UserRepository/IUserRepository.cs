using CinemaTicketBooking.Models;
using CinemaTicketBooking.Repositories.GenericRepository;

namespace CinemaTicketBooking.Repositories.UserRepository
{
    public interface IUserRepository : IGenericRepository<User>
    {
        User FindByUserName(string userName);
    }
    
}
