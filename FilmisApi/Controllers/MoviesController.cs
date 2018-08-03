using System.Collections.Generic;
using System.Linq;
using FilmisApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace FilmisApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class MoviesController : ControllerBase
    {
        private readonly MovieContext _context;

        public MoviesController(MovieContext movieContext)
        {
            _context = movieContext;


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
        }

        // GET: api/Movies
        [HttpGet]
        public IEnumerable<Movie> GetMovies()
        {
            return _context.Movies.ToList();
        }

        //GET: api/Movies/5/actors
        [HttpGet("{id}/actors", Name = "GetActors")]
        public IActionResult GetTheActorsFromTheMovie(int id)
        {
            var movie = _context.Movies.Find(id);

            if (movie == null)            
                return NotFound();

            return Ok(movie.Actors);            
        }

        // GET: api/Movies/5
        [HttpGet("{id}", Name = "GetMovie")]
        public IActionResult GetMovie(int id)
        {
            var movie = _context.Movies.Find(id);

            if (movie == null)            
                return NotFound();
            
            return Ok(movie);            
        }
        
        // POST: api/Movies
        [HttpPost]
        public IActionResult CreateMovie([FromBody] Movie movie)
        {            
            if (movie == null)
                return BadRequest();

            _context.Movies.Add(movie);
            _context.SaveChanges();

            return CreatedAtRoute("GetMovie", new { id = movie.Id }, movie);
        }
        
        // PUT: api/Movies/5
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody]Movie movie)
        {
            if (movie == null || movie.Id != id)
                return BadRequest();

            var selectedMovie = _context.Movies.Where(x => x.Id == movie.Id).FirstOrDefault();

            if (selectedMovie == null)
                return NotFound();

            selectedMovie = UpdateTheMovie(movie, selectedMovie);

            _context.Movies.Update(selectedMovie);
            _context.SaveChanges();

            return NoContent();
        }

        private Movie UpdateTheMovie(Movie movie, Movie selectedMovie)
        {
            selectedMovie.Name = movie.Name;
            selectedMovie.Year = movie.Year;

            return selectedMovie;
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var selectedMovie = _context.Movies.Find(id);

            if (selectedMovie == null)           
                return NotFound();

            _context.Movies.Remove(selectedMovie);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
