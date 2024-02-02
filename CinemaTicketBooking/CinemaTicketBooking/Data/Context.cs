using CinemaTicketBooking.Models;
using FilmTicketBooking.Models;
using Microsoft.EntityFrameworkCore;
using System.Numerics;

namespace CinemaTicketBooking.Data
{
    public class Context : DbContext
    {
        public DbSet<Client> Clients { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Film> Films { get; set; }
        public DbSet<User> Users { get; set; }



        public Context(DbContextOptions<Context> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //FLUENT API 
            //One to Many: un film poate avea mai multe bilete asociate MODEL 1=FILM MODEL2=BILETE
            modelBuilder.Entity<Film>()
                .HasMany(f => f.Tickets)
                .WithOne(t => t.Film)
                .OnDelete(DeleteBehavior.Restrict);

            //Many to Many, client(m3)-film 
            //Cheie compusa 

            modelBuilder.Entity<RelatieClientFilm>()
                 .HasKey(nr => new { nr.ClientId, nr.FilmId });

            modelBuilder.Entity<RelatieClientFilm>()
                .HasOne<Client>(nr => nr.Client)
                .WithMany(cl => cl.RelatieClientFilms)
                .HasForeignKey(nr => nr.ClientId);

            modelBuilder.Entity<RelatieClientFilm>()
                .HasOne<Film>(nr => nr.Film)
                .WithMany(fl => fl.RelatieClientFilms)
                .HasForeignKey(nr => nr.FilmId);

            //One to One: fiecare bilet(m5) este asociat cu un singur client anume

            modelBuilder.Entity<Ticket>()
                .HasOne(m5 => m5.Client)
                .WithOne(m6 => m6.Ticket)
                .HasForeignKey<Client>(m6 => m6.TicketId);


            base.OnModelCreating(modelBuilder);
        }
    }
}
