using System.Collections.Generic;

namespace FilmisApi.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }
        public List<Actor> Actors { get; set; }
    }
}
