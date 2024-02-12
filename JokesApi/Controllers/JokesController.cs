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
            return joke;
        }

        [HttpPut("{id}")]
        public ActionResult PutJoke(int id, JokeModel jokeModel)
        {
            _serviceJoke.UpdateJoke(id, jokeModel);
            return Ok(jokeModel);
        }

        [HttpPost]
        public async Task<ActionResult<Joke>> CreateJoke(JokeModel jokeModel)
        {
            await _serviceJoke.AddJoke(jokeModel);
            return CreatedAtAction("GetJokeById", new { id = jokeModel.Id }, jokeModel);
        }

        [HttpDelete]
        public ActionResult DeleteJoke(int id)
        {
            _serviceJoke.DeleteJoke(id);
            return Ok("Joke has been deleted.");   
        }               
    }
}
