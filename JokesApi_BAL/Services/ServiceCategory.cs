using JokesApi_DAL.Contracts;
using JokesApi_DAL.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace JokesApi_BAL.Services
{
    public class ServiceCategory
    {
        private readonly IRepositoryCategory _repositoryCategory;

        public ServiceCategory(IRepositoryCategory repositoryCategory)
        {
            
            _repositoryCategory = repositoryCategory;
        }
        public async Task<ActionResult<IEnumerable<Category>>> GetAllCategories()
        {
            return await _repositoryCategory.GetAllCategories();
        }

        public async Task<Category> GetCategoryById(int id)
        {
            var category = await _repositoryCategory.GetCategoryById(id);
            
            return category;
        }
    }
}
