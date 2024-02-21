using Microsoft.AspNetCore.Mvc;
using JokesApi_BAL.Services;
using JokesApi_DAL.Entities;
using JokesApi_BAL.Models;


namespace JokesApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ServiceCategory _serviceCategory;
                
        public CategoriesController(ServiceCategory serviceCategory)
        {
            _serviceCategory = serviceCategory;            
        }

        [HttpGet]
        public ActionResult<List<CategoryModel>> GetAllCategories()
        {
            return _serviceCategory.GetAllCategories();
        }

       
        [HttpGet("{id}")]
        public ActionResult<Result<CategoryModel, Error>> GetCategoryById(int id)
        {
            var categoryResult = _serviceCategory.GetCategoryById(id);

            if (categoryResult.Error != null)
            {
                return NotFound(categoryResult.Error.Description);
            }
            else
                return Ok(categoryResult.Value);
        }

        [HttpPost]
        public async Task<ActionResult<Result<Category, Error>>> CreateCategory(CategoryModel categoryModel)
        {
            var categoryResult = await _serviceCategory.AddCategory(categoryModel);

            if (categoryResult.Error != null) {
                return BadRequest(categoryResult.Error.Description);
            }
            else                
                return CreatedAtAction("GetCategoryById", new { categoryResult.Value.Id }, categoryResult.Value);
        }

        [HttpPut("{id}")]
        public ActionResult PutCategory(int id, string name)
        {
            var result = _serviceCategory.UpdateCategory(id, name);

            if (result.Error != null)
            {
                return BadRequest(result.Error.Description);
            }
            return Ok(result.Value);
        }
                

        [HttpDelete("{id}")]
        public ActionResult DeleteCategory(int id)
        {
            var result = _serviceCategory.DeleteCategory(id);

            if (result.Error == Error.None)
            {
                return Ok("Category has been deleted");
            }
            else
                return NotFound(result.Error.Description);            
        }
    }
}
