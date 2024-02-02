using CinemaTicketBooking.Data;
using CinemaTicketBooking.Models;
using CinemaTicketBooking.Repositories.GenericRepository;

namespace CinemaTicketBooking.Repositories.UserRepository
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(Context context) : base(context) 
        {

        }  
        public User FindByUserName(string userName)
        {
            return _table.FirstOrDefault(x => x.UserName == userName);
        }
    }
    
}
