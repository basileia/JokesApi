using Microsoft.AspNetCore.Mvc;
using JokesApi_BAL.Services;
using JokesApi_BAL.Models.Joke;
using JokesApi_BAL.Models.JokeLike;

namespace JokesApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JokesController : BaseController
    {
        private readonly ServiceJoke _serviceJoke;
        private readonly ServiceJokeLike _serviceJokeLike;

        public JokesController(ServiceJoke serviceJoke, ServiceJokeLike serviceJokeLike)
        {
            _serviceJoke = serviceJoke;
            _serviceJokeLike = serviceJokeLike;
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

        [HttpPut("{id}")]
        public ActionResult<JokeDetailModel> UpdateJoke(int id, UpdateJokeModel jokeModel)
        {
            return GetResponse(_serviceJoke.UpdateJoke(id, jokeModel));
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteJoke(int id)
        {
            return GetResponse(_serviceJoke.DeleteJoke(id));
        }

        [HttpGet("random")]
        public ActionResult GetRandom()
        {
            return GetResponse(_serviceJoke.GetRandomJoke());
        }

        [HttpPost("{id}/like")]
        public ActionResult LikeJoke(int id)
        {
            var model = new JokeLikeUpdateModel
            {
                JokeId = id
            };

            return GetResponse(_serviceJokeLike.AddLike(model));
        }

        [HttpGet("{id}/likes/count")]
        public ActionResult GetLikeCount(int id)
        {
            return GetResponse(_serviceJokeLike.GetLikeCount(id));
        }
    }
}
