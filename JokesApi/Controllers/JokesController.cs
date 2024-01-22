using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using JokesApi_DAL.Data;
using JokesApi_DAL.Entities;


namespace JokesApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class JokesController : ControllerBase
    {
        private readonly AppDbContext _context;
        //private readonly IMapper _mapper;

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

        //        // GET: api/Jokes/5
        //        [HttpGet("{id}")]
        //        public async Task<ActionResult<Joke>> GetJoke(int id)
        //        {            
        //            var joke = await _context.Jokes
        //                .Include(_ => _.Category)
        //                .Where(_ => _.Id == id)
        //                .FirstOrDefaultAsync();

        //            if (joke == null)
        //            {
        //                return NotFound();
        //            }

        //            return joke;
        //        }

        //        // PUT: api/Jokes/5
        //        [HttpPut("{id}")]
        //        public async Task<IActionResult> PutJoke(int id, JokeDto joke)
        //        {
        //            if (id != joke.Id)
        //            {
        //                return BadRequest();
        //            }

        //            if (!CategoryExists(joke.CategoryId))
        //            {
        //                return NotFound("Category not found.");
        //            }

        //            var updateJoke = _mapper.Map<Joke>(joke);
        //            updateJoke.CreatedAt = DateTime.Now;                      

        //            _context.Entry(updateJoke).State = EntityState.Modified;

        //            try
        //            {
        //                await _context.SaveChangesAsync();
        //            }
        //            catch (DbUpdateConcurrencyException)
        //            {
        //                if (!JokeExists(id))
        //                {
        //                    return NotFound();
        //                }
        //                else
        //                {
        //                    throw;
        //                }
        //            }

        //            return NoContent();
        //        }

        //        // POST: api/Jokes
        //        [HttpPost]
        //        public async Task<ActionResult<Joke>> PostJoke(JokeDto joke)
        //        {
        //            if (JokeExists(joke.Id))
        //            {
        //                return BadRequest("Joke Id already exists.");
        //            }

        //            if (!CategoryExists(joke.CategoryId))
        //            {
        //                return NotFound("Category not found.");
        //            }

        //            var newJoke = _mapper.Map<Joke>(joke);         
        //            newJoke.CreatedAt = DateTime.Now;
        //            _context.Jokes.Add(newJoke);
        //            await _context.SaveChangesAsync();
        //            return CreatedAtAction("GetJoke", new { id = newJoke.Id }, newJoke);
        //        }

        //        // DELETE: api/Jokes/5
        //        [HttpDelete("{id}")]
        //        public async Task<IActionResult> DeleteJoke(int id)
        //        {
        //            var joke = await _context.Jokes.FindAsync(id);
        //            if (joke == null)
        //            {
        //                return NotFound();
        //            }

        //            _context.Jokes.Remove(joke);
        //            await _context.SaveChangesAsync();

        //            return NoContent();
        //        }

        //        private bool JokeExists(int id)
        //        {
        //            return _context.Jokes.Any(e => e.Id == id);
        //        }

        //        private bool CategoryExists(int id)
        //        {
        //            return _context.Categories.Any(e => e.Id == id);
        //        }
    }
}
