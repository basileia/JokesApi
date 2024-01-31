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

        // lepší mít throw new Exception() v ServiceCategory nebo tady ActionResult (NotFound?) - business logic, nebo ještě jinak?
        [HttpGet("{id}")]
        public ActionResult<CategoryModel> GetCategoryById(int id)
        {
            var category = _serviceCategory.GetCategoryById(id);

            if (category == null)
            {
                return NotFound("Invalid Id");
            }

            return category;
        }

        [HttpPut("{id}")]
        public ActionResult PutCategory(int id, CategoryModel categoryModel)
        {
            if (id != categoryModel.Id)
            {
                return BadRequest();
            }            
            
            var existingCategory = _serviceCategory.GetCategoryById(id);

            if (existingCategory == null)
            {
                return NotFound();
            }

            categoryModel.Id = id;
            _serviceCategory.UpdateCategory(categoryModel);

            return Ok();
        }


        [HttpPost]
        public async Task<ActionResult<Category>> CreateCategory(CategoryModel categoryModel)
        {
            await _serviceCategory.AddCategory(categoryModel);

            return CreatedAtAction("GetCategoryById", new { id = categoryModel.Id }, categoryModel);
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteCategory(int id)
        {
            var existingCategory = _serviceCategory.GetCategoryById(id);

            if (existingCategory == null)
            {
                return NotFound();
            }

            _serviceCategory.DeleteCategory(id);

            return Ok();
        }




    }
}
