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
        private readonly MovieContext _movieContext;

        public MoviesController(MovieContext movieContext)
        {
            _movieContext = movieContext;

            var myMovies = new List<Movie>()
            {               
                new Movie { Name = "Space Jam", Year = 1996, Actors = {}},
                new Movie { Name = "Uncle Drew", Year = 2018, Actors = {}},
            };

            if (_movieContext.Movies.Count() == 0)
            {
                _movieContext.Movies.AddRange(myMovies);
                _movieContext.SaveChanges();                
            }            
        }

        // GET: api/Movies
        [HttpGet]
        public IEnumerable<Movie> GetAll()
        {
            return _movieContext.Movies.ToList();            
        }

        // GET: api/Movies/5
        [HttpGet("{id}", Name = "GetMovie")]
        public IActionResult GetByID(int id)
        {
            var movie = _movieContext.Movies.Find(id);
            if (movie == null)
            {
                return NotFound();
            }
            return Ok(movie);            
        }
        
        // POST: api/Movies
        [HttpPost]
        public IActionResult Create([FromBody] Movie movie)
        {            
            if (movie == null)
                return BadRequest();

            _movieContext.Movies.Add(movie);
            _movieContext.SaveChanges();

            return CreatedAtRoute("GetMovie", new { id = movie.Id }, movie);
        }
        
        // PUT: api/Movies/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
