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
                var client1 = new Client
                {
                    FirstName = "Alex",
                    LastName = "Popescu",
                    Age = 21,
                    TelephoneNumber = "0741258740",
                    Email = "alex@yahoo.com",
                   // DateCreated = DateTime.Now
                };

                var client2 = new Client
                {
                    FirstName = "Andreea",
                    LastName = "Mindrescu",
                    Age = 21,
                    TelephoneNumber = "0741265740",
                    Email = "andr27@yahoo.com",
                   // DateCreated = DateTime.Now
                };

                _context.Clients.Add(client1);
                _context.Clients.Add(client2);

                _context.SaveChanges();


            }
        }

     
    }
}
