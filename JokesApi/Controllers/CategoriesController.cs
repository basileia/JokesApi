using Microsoft.AspNetCore.Mvc;
using JokesApi_BAL.Services;
using JokesApi_DAL.Entities;
using JokesApi_BAL.Models.Category;
using JokesApi_BAL.Models.Errors;

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
        public ActionResult<CategoryModel> CreateCategory(CreateCategoryModel categoryModel)
        {
            var result = _serviceCategory.AddCategory(categoryModel);

            if (!result.IsSuccess || result.Value == null)
            {
                return GetResponse(result); 
            }

            return GetResponse(result, nameof(GetCategory), new { id = result.Value.Id });
        }

        [HttpPut("{id}")]
        public ActionResult<CategoryDetailModel> UpdateCategory(int id, CategoryModel categoryModel)
        {
            return GetResponse(_serviceCategory.UpdateCategory(id, categoryModel));
        }

        /// <summary>
        /// Deletes a category from the database.
        /// </summary>
        /// <param name="id">ID of the category to delete</param>
        /// <remarks>
        /// When a category is deleted, all jokes belonging to this category will be automatically deleted as well (cascade delete).
        /// </remarks>
        /// <response code="204">Category was successfully deleted</response>
        /// <response code="404">Returns CategoryErrors.CategoryNotFound when category with the specified ID does not exist</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(CategoryErrors), StatusCodes.Status404NotFound)]
        public ActionResult DeleteCategory(int id)
        {
            return GetResponse(_serviceCategory.DeleteCategory(id));
        }        
    }
}
