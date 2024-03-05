using Microsoft.AspNetCore.Mvc;
using JokesApi_BAL.Models;

namespace JokesApi.Controllers
{
    public class BaseController : ControllerBase
    {
        public ActionResult<T> GetResponse<T, TError>(Result<T, TError> result)
        {
            if (!result.IsSuccess)
            {
                return BadRequest(result.Error);
            }
            return Ok(result.Value);
        }
    }
}
