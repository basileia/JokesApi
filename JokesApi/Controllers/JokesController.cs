using Microsoft.AspNetCore.Mvc;
using JokesApi_DAL.Entities;
using JokesApi_BAL.Services;
using JokesApi_BAL.Models.Joke;

//namespace JokesApi.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class JokesController : BaseController
//    {
//        private readonly ServiceJoke _serviceJoke;
        
//        public JokesController(ServiceJoke serviceJoke)
//        {
//            _serviceJoke = serviceJoke;
//        }

//        [HttpGet]
//        public ActionResult<List<JokeModel>> GetJokes()
//        {
//            return _serviceJoke.GetAllJokes();
//        }

//        [HttpGet("{id}")]
//        public ActionResult<JokeModel> GetJoke(int id)
//        {
//            return GetResponse(_serviceJoke.GetJokeById(id));            
//        }

//        [HttpPost]
//        public async Task<ActionResult<JokeModel>> CreateJoke(JokeModel jokeModel)
//        {
//            var result = await _serviceJoke.AddJoke(jokeModel);
            
//            if (!result.IsSuccess)
//            {
//                return BadRequest(result.Error);
//            }

//            return CreatedAtAction(nameof(GetJoke), new { id = result.Value.Id }, result.Value);
//        }

//        [HttpPut("{id}")]
//        public ActionResult<JokeModel> UpdateJoke(int id, JokeModel jokeModel)
//        {
//            return GetResponse(_serviceJoke.UpdateJoke(id, jokeModel));
//        }

//        [HttpDelete("{id}")]
//        public ActionResult<bool> DeleteJoke(int id)
//        {            
//            return GetResponse(_serviceJoke.DeleteJoke(id));        
//        }               
//    }
//}
