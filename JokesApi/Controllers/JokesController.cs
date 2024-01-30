using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using JokesApi_DAL.Entities;
using JokesApi_BAL.Services;
using JokesApi_BAL.Models;


namespace JokesApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class JokesController : ControllerBase
    {
        private readonly ServiceJoke _serviceJoke;
        
        public JokesController(ServiceJoke serviceJoke)
        {
            _serviceJoke = serviceJoke;
        }

        [HttpGet]
        public List<JokeModel> GetAllJokes()
        {
            return _serviceJoke.GetAllJokes();
        }

        [HttpGet("{id}")]
        public ActionResult<JokeModel> GetJokeById(int id)
        {
            var joke = _serviceJoke.GetJokeById(id);

            if (joke == null)
            {
                return NotFound("Invalid Id");
            }

            return joke;
        }

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

        // POST: api/Jokes
        [HttpPost]
        public async Task<ActionResult<Joke>> CreateJoke(JokeModel jokeModel)
        {
            await _serviceJoke.AddJoke(jokeModel);
            return CreatedAtAction("GetJokeById", new { id = jokeModel.Id }, jokeModel);
        }

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
