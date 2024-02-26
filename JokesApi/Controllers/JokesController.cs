using Microsoft.AspNetCore.Mvc;
using JokesApi_DAL.Entities;
using JokesApi_BAL.Services;
using JokesApi_BAL.Models;


namespace JokesApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class JokesController : BaseController
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
            return GetResponse(_serviceJoke.GetJokeById(id));            
        }

        [HttpPost]
        public async Task<ActionResult<Joke>> CreateJoke(JokeModel jokeModel)
        {
            return GetResponse(await _serviceJoke.AddJoke(jokeModel));
        }

        [HttpPut("{id}")]
        public ActionResult<JokeModel> PutJoke(int id, JokeModel jokeModel)
        {
            return GetResponse(_serviceJoke.UpdateJoke(id, jokeModel));
        }

        [HttpDelete]
        public ActionResult DeleteJoke(int id)
        {
            var result = _serviceJoke.DeleteJoke(id);

            if (result.Error == Error.None)
            {
                return Ok("Joke has been deleted.");
            }
            return BadRequest(result.Error);              
        }               
    }
}
