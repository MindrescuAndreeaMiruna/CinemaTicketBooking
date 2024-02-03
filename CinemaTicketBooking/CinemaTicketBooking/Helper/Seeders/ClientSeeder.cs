using CinemaTicketBooking.Data;
using FilmTicketBooking.Models;

namespace CinemaTicketBooking.Helper.Seeders
{
    public class ClientSeeder
    {
        public readonly Context _context;

        public ClientSeeder(Context context)
        {
            _context = context;
        }

        public void SeedInitialClient()
        {
            if(!_context.Clients.Any())
            {
                var ticket1 = _context.Tickets.First();
                var client1 = new Client
                {
                    FirstName = "Alex",
                    LastName = "Popescu",
                    Age = 21,
                    TelephoneNumber = "0741258740",
                    Email = "alex@yahoo.com",
                    Ticket = ticket1
                   
                };
              
                var ticket2 = _context.Tickets.Skip(1).FirstOrDefault();
                var client2 = new Client
                {
                    FirstName = "Andreea",
                    LastName = "Mindrescu",
                    Age = 21,
                    TelephoneNumber = "0741265740",
                    Email = "andr27@yahoo.com",
                    Ticket = ticket2
                   
                };

                _context.Clients.Add(client1);
                _context.Clients.Add(client2);

                _context.SaveChanges();


            }
        }

     
    }
}
