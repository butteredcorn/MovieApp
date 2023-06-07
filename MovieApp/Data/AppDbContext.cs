using Microsoft.EntityFrameworkCore;
using MovieApp.Models;

namespace MovieApp.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ActorMovie>()
                .HasKey(x => new { x.ActorId, x.MovieId });

            modelBuilder.Entity<ActorMovie>()
                .HasOne(x => x.Movie)
                .WithMany(x => x.ActorMovies)
                .HasForeignKey(x => x.MovieId);

            modelBuilder.Entity<ActorMovie>()
                .HasOne(x => x.Actor)
                .WithMany(x => x.ActorMovies)
                .HasForeignKey(x => x.ActorId);

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Actor> Actors { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<ActorMovie> ActorsMovies { get; set; }
        public DbSet<Cinema> Cinbemas { get; set; }
        public DbSet<Producer> Producers { get; set; }

    }
}
