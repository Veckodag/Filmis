using Microsoft.EntityFrameworkCore;

namespace FilmisApi.Models
{
    public class MovieContext : DbContext
    {
        public MovieContext(DbContextOptions<MovieContext> options) : base(options)
        {
        }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Actor> Actors { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Movie>().ToTable("Movie");
        //    modelBuilder.Entity<Actor>().ToTable("Actor");            
        //}
    }
}

//Old Stuff
/*
           var myActors = new List<Actor>()
            {
                new Actor { Name = "Michael Jordan"},
                new Actor { Name = "Bill Murray" },
                new Actor { Name = "Kyrie Irving" },
                new Actor { Name = "Nate Robinson" }
            };

            if (_context.Actors.Count() == 0)
            {
                _context.Actors.AddRange(myActors);
                _context.SaveChanges();
            }

            var myMovies = new List<Movie>()
            {
                new Movie { Name = "Space Jam", Year = 1996, Actors = _context.Actors.Take(2).ToList()},
                new Movie { Name = "Uncle Drew", Year = 2018, Actors = _context.Actors.Skip(2).Take(2).ToList()},
            };

            if (_context.Movies.Count() == 0)
            {
                _context.Movies.AddRange(myMovies);
                _context.SaveChanges();
            }
            
                var myActors = new List<Actor>()
            {
                new Actor { Name = "Will Ferrell"},
                new Actor { Name = "Woody Harrelson" },
                new Actor { Name = "Samuel L. Jackson" },
                new Actor { Name = "Denzel Washington" },
                new Actor { Name = "Wesley Snipes"}
            };

            if (_context.Actors.Count() == 0)
            {
                _context.Actors.AddRange(myActors);
                _context.SaveChanges();
            }
*/