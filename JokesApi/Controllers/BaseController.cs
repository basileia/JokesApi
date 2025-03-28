using Microsoft.AspNetCore.Mvc;
using JokesApi_BAL.Models;
using LanguageExt;

namespace JokesApi.Controllers
{
    public class BaseController : ControllerBase
    {
        public ActionResult GetResponse<T, TError>(Result<T, TError> result)
        {            
            if (!result.IsSuccess)
            {
                return BadRequest(result.Error);
            }

            //DELETE operace
            if (typeof(T) == typeof(Unit))
            {
                return NoContent();
            }

            return Ok(result.Value);
        }
    }
}
