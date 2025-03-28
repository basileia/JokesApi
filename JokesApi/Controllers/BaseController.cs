using Microsoft.AspNetCore.Mvc;
using JokesApi_BAL.Models;
using LanguageExt;

namespace JokesApi.Controllers
{
    public class BaseController : ControllerBase
    {
        public ActionResult GetResponse<T, TError>(Result<T, TError> result, string actionName = null, object routeValues = null)
        {            
            if (!result.IsSuccess)
            {
                return BadRequest(result.Error);
            }

            //DELETE
            if (typeof(T) == typeof(Unit))
            {
                return NoContent();
            }

            //CREATE
            if (actionName != null && routeValues != null)
            {
                return CreatedAtAction(actionName, routeValues, result.Value);
            }

            return Ok(result.Value);
        }
    }
}
