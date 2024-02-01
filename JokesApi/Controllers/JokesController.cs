using Microsoft.AspNetCore.Mvc;
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
        public ActionResult<List<JokeModel>> GetAllJokes()
        {
            return _serviceJoke.GetAllJokes();
        }

        [HttpGet("{id}")]
        public ActionResult<JokeModel> GetJokeById(int id)
        {
            var joke = _serviceJoke.GetJokeById(id);

            if (joke == null)
            {
                return BadRequest("Invalid Id");
            }

            return joke;
        }

        // PUT: api/Jokes/5
        [HttpPut("{id}")]
        public ActionResult PutJoke(int id, JokeModel jokeModel)
        {
            if (id != jokeModel.Id)
            {
                return BadRequest("The id in the path must be the same as the joke id.");
            }

            var existingJoke = _serviceJoke.GetJokeById(id);

            if (existingJoke == null)
            {
                return BadRequest("Joke not found");
            }

            jokeModel.Id = id;
            _serviceJoke.UpdateJoke(jokeModel);

            return Ok(jokeModel);
        }

        [HttpPost]
        public async Task<ActionResult<Joke>> CreateJoke(JokeModel jokeModel)
        {
            await _serviceJoke.AddJoke(jokeModel);
            return CreatedAtAction("GetJokeById", new { id = jokeModel.Id }, jokeModel);
        }

        // DELETE: api/Jokes/5
        [HttpDelete("{id}")]
        public ActionResult DeleteJoke(int id)
        {
            var existingJoke = _serviceJoke.GetJokeById(id);
            
            if (existingJoke == null)
            {
                return BadRequest("Joke not found");
            }

            _serviceJoke.DeleteJoke(id);

            return Ok("Joke has been deleted.");         
        }               
    }
}
