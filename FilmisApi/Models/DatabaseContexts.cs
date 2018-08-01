using Microsoft.EntityFrameworkCore;

namespace FilmisApi.Models
{
    public class MovieContext : DbContext
    {
        public MovieContext(DbContextOptions<MovieContext> options) : base(options)
        {
        }
        public DbSet<Movie> Movies { get; set; }
    }
    public class ActorContext : DbContext
    {
        public ActorContext(DbContextOptions<ActorContext> options) : base(options)
        {
        }
        public DbSet<Actor> Actors { get; set; }
    } 
}

//var myActors = new List<Actor>()
//            {
//                new Actor { Id = 1, Name = "Michael Jordan"},
//                new Actor { Id = 2, Name = "Bill Murray" }
//            };
