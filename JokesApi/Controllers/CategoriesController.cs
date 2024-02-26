using Microsoft.AspNetCore.Mvc;
using JokesApi_BAL.Services;
using JokesApi_DAL.Entities;
using JokesApi_BAL.Models;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;


namespace JokesApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CategoriesController : BaseController
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
        public ActionResult<CategoryModel> GetCategoryById(int id)
        {
            return GetResponse(_serviceCategory.GetCategoryById(id));
        }
 
        [HttpPost]
        public async Task<ActionResult<Category>> CreateCategory(CategoryModel categoryModel)
        {         
            return GetResponse(await _serviceCategory.AddCategory(categoryModel));
        }

        [HttpPut("{id}")]
        public ActionResult<CategoryModel> PutCategory(int id, string name)
        {
            return GetResponse(_serviceCategory.UpdateCategory(id, name));
        }               

        [HttpDelete("{id}")]
        public ActionResult DeleteCategory(int id)
        {
            var result = _serviceCategory.DeleteCategory(id);

            if (result.Error == Error.None)
            {
                return Ok("Category has been deleted");                
            }
            return BadRequest(result.Error);
        }        
    }
}
