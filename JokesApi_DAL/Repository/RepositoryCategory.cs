using JokesApi_DAL.Contracts;
using JokesApi_DAL.Data;
using JokesApi_DAL.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace JokesApi_DAL.Repository
{
    public class RepositoryCategory : IRepositoryCategory
    {
        private readonly AppDbContext _context;

        public RepositoryCategory(AppDbContext context)
        {
            _context = context;
        }
                       
        public async Task<ActionResult<IEnumerable<Category>>> GetAllCategories()
        {
            var categories = await _context.Categories
                .Include(_ => _.Jokes)
                .ToListAsync();

            return categories;
        }

        public async Task<Category> GetCategoryById(int id)
        {
            var category = await _context.Categories
                .Include(_ => _.Jokes)
                .Where(_ => _.Id == id)
                .FirstOrDefaultAsync();
            
            return category;
        }
    }
}
