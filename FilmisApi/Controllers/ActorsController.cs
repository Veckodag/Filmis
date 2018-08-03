using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FilmisApi.Models;

namespace FilmisApi.Controllers
{
    [Produces("application/json")]
    [Route("api/Actors")]
    public class ActorsController : Controller
    {
        private readonly MovieContext _context;

        public ActorsController(MovieContext context)
        {
            _context = context;

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
        }

        // GET: api/Actors
        [HttpGet]
        public IEnumerable<Actor> GetActors()
        {
            return _context.Actors;
        }

        // GET: api/Actors/5
        [HttpGet("{id}", Name ="GetActor")]
        public async Task<IActionResult> GetActor([FromRoute] int id)
        {
            var actor = await _context.Actors.SingleOrDefaultAsync(m => m.Id == id);

            if (actor == null)            
                return NotFound();            

            return Ok(actor);
        }

        // POST: api/Actors
        [HttpPost]
        public async Task<IActionResult> CreateActor([FromBody] Actor actor)
        {
            if (actor == null)            
                return BadRequest();
            
            _context.Actors.Add(actor);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetActor", new { id = actor.Id }, actor);
        }

        // PUT: api/Actors/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateActor(int id, [FromBody] Actor actor)
        {
            if (actor == null || actor.Id != id)            
                return BadRequest();
            

            _context.Entry(actor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ActorExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE: api/Actors/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteActor([FromRoute] int id)
        {
            var actor = await _context.Actors.SingleOrDefaultAsync(m => m.Id == id);

            if (actor == null)            
                return NotFound();            

            _context.Actors.Remove(actor);
            await _context.SaveChangesAsync();

            return Ok(actor);
        }

        private bool ActorExists(int id)
        {
            return _context.Actors.Any(e => e.Id == id);
        }
    }
}