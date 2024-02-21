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
            var jokeResult = _serviceJoke.GetJokeById(id);

            if (jokeResult.Error != null)
            {
                return NotFound(jokeResult.Error.Description);
            }
            return Ok(jokeResult.Value);
        }

        [HttpPost]
        public async Task<ActionResult<Joke>> CreateJoke(JokeModel jokeModel)
        {
            var result = await _serviceJoke.AddJoke(jokeModel);

            if (result.Error != null)
            {
                return BadRequest(result.Error.Description);
            }
            return CreatedAtAction("GetJokeById", new { id = result.Value.Id }, result.Value);
        }

        [HttpPut("{id}")]
        public ActionResult PutJoke(int id, JokeModel jokeModel)
        {
            var result = _serviceJoke.UpdateJoke(id, jokeModel);

            if (result.Error != null)
            {
                return BadRequest(result.Error.Description);
            }
            return Ok(jokeModel);
        }

        [HttpDelete]
        public ActionResult DeleteJoke(int id)
        {
            var result = _serviceJoke.DeleteJoke(id);

            if (result.Error == Error.None)
            {
                return Ok("Joke has been deleted.");
            }
            return BadRequest(result.Error.Description);              
        }               
    }
}
