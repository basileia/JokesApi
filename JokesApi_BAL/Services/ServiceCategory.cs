using JokesApi_DAL.Contracts;
using JokesApi_DAL.Entities;
using JokesApi_DAL.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace JokesApi_BAL.Services
{
    public class ServiceCategory
    {
        private readonly IRepositoryCategory _repositoryCategory;

        public ServiceCategory(IRepositoryCategory repositoryCategory)
        {
            Console.WriteLine("Service category");
            _repositoryCategory = repositoryCategory;
        }
        public async Task<ActionResult<IEnumerable<Category>>> GetAllCategories()
        {
            return await _repositoryCategory.GetAllCategories();
        }
    }
}
