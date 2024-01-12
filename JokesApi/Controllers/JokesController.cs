using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using JokesApi.Data;
using JokesApi.Models;

namespace JokesApi.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class JokesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public JokesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Jokes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Joke>>> GetJokes()
        {
            return await _context.Jokes.ToListAsync();
        }

        // GET: api/Jokes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Joke>> GetJoke(int id)
        {
            var joke = await _context.Jokes.FindAsync(id);

            if (joke == null)
            {
                return NotFound();
            }

            return joke;
        }

        // PUT: api/Jokes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutJoke(int id, Joke joke)
        {
                     
            if (id != joke.Id)
            {
                return BadRequest();
            }

            joke.CreatedAt = DateTime.Now;
            _context.Entry(joke).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!JokeExists(id))
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

        // POST: api/Jokes
        [HttpPost]
        public async Task<ActionResult<Joke>> PostJoke(Joke joke)
        {
            joke.CreatedAt = DateTime.Now;
            _context.Jokes.Add(joke);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetJoke", new { id = joke.Id }, joke);
        }

        // DELETE: api/Jokes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteJoke(int id)
        {
            var joke = await _context.Jokes.FindAsync(id);
            if (joke == null)
            {
                return NotFound();
            }

            _context.Jokes.Remove(joke);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool JokeExists(int id)
        {
            return _context.Jokes.Any(e => e.Id == id);
        }
    }
}
