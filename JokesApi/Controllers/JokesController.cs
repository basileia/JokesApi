using Microsoft.AspNetCore.Mvc;
using JokesApi_BAL.Services;
using JokesApi_BAL.Models.Joke;
using JokesApi_BAL.Models.Category;

namespace JokesApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JokesController : BaseController
    {
        private readonly ServiceJoke _serviceJoke;

        public JokesController(ServiceJoke serviceJoke)
        {
            _serviceJoke = serviceJoke;
        }

        [HttpGet]
        public ActionResult<List<JokeModel>> GetJokes()
        {
            return _serviceJoke.GetAllJokes();
        }

        [HttpGet("{id}")]
        public ActionResult<JokeDetailModel> GetJoke(int id)
        {
            return GetResponse(_serviceJoke.GetJokeById(id));
        }

        [HttpPost]
        public ActionResult<JokeModel> CreateJoke(CreateJokeModel jokeModel)
        {
            var result = _serviceJoke.AddJoke(jokeModel);

            if (!result.IsSuccess || result.Value == null)
            {
                return GetResponse(result);
            }

            return GetResponse(result, nameof(GetJoke), new { id = result.Value.Id });
        }

        //[HttpPut("{id}")]
        //public ActionResult<JokeModel> UpdateJoke(int id, JokeModel jokeModel)
        //{
        //    return GetResponse(_serviceJoke.UpdateJoke(id, jokeModel));
        //}

        //[HttpDelete("{id}")]
        //public ActionResult<bool> DeleteJoke(int id)
        //{
        //    return GetResponse(_serviceJoke.DeleteJoke(id));
        //}
    }
}
