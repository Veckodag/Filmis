using System.Collections.Generic;

namespace FilmisApi.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }
        public List<Actor> Actors { get; set; }

        //var myMovie = new Movie
        //{
        //    Id = 1,
        //    Name = "Space Jam",
        //    Year = 1996,
        //    Actors =
        //            { new Actor { Id = 1, Name = "Michael Jordan"},
        //              new Actor { Id = 2, Name = "Bill Murray" }
        //            }
        //};
    }    
}
