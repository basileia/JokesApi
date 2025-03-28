using Microsoft.AspNetCore.Mvc;
using JokesApi_BAL.Services;
using JokesApi_DAL.Entities;
using JokesApi_BAL.Models.Category;

namespace JokesApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : BaseController
    {
        private readonly ServiceCategory _serviceCategory;
                
        public CategoriesController(ServiceCategory serviceCategory)
        {
            _serviceCategory = serviceCategory;            
        }

        [HttpGet]
        public ActionResult<List<CategoryModel>> GetCategories()
        {
            return _serviceCategory.GetAllCategories();
        }

        [HttpGet("{id}")]
        public ActionResult<CategoryDetailModel> GetCategory(int id)
        {
            return GetResponse(_serviceCategory.GetCategoryById(id));
        }
 
        [HttpPost]
        public ActionResult<Category> CreateCategory(CreateCategoryModel categoryModel)
        {
            var result = _serviceCategory.AddCategory(categoryModel);

            if (!result.IsSuccess)
            {
                return BadRequest(result.Error);
            }

            return CreatedAtAction(nameof(GetCategory), new { id = result.Value.Id }, result.Value);
        }

        [HttpPut("{id}")]
        public ActionResult<CategoryDetailModel> UpdateCategory(int id, CategoryModel categoryModel)
        {
            return GetResponse(_serviceCategory.UpdateCategory(id, categoryModel));
        }               

        [HttpDelete("{id}")]
        public ActionResult DeleteCategory(int id)
        {
            return GetResponse(_serviceCategory.DeleteCategory(id));
        }        
    }
}
