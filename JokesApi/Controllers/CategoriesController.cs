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
            
            var result = categoryResult.Match(resultValue => resultValue, error => error);

            if (result.Error != null)
            {
                return NotFound(result.Error.Description);
            }
            else
                return Ok(result.Value);
        }

        [HttpPost]
        public async Task<ActionResult<Category>> CreateCategory(CategoryModel categoryModel)
        {
            await _serviceCategory.AddCategory(categoryModel);
            return CreatedAtAction("GetCategoryById", new { categoryModel.Id }, categoryModel);
        }

        [HttpPut("{id}")]
        public ActionResult PutCategory(int id, CategoryModel categoryModel)
        {
            _serviceCategory.UpdateCategory(id, categoryModel);
            return Ok(categoryModel);
        }
                

        [HttpDelete("{id}")]
        public ActionResult DeleteCategory(int id)
        {
            _serviceCategory.DeleteCategory(id);
            return Ok("Category has been deleted");
        }
    }
}
