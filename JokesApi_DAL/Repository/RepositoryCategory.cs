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
                       
        public List<Category> GetAllCategories()
        {
            var categories = _context.Categories
                .Include(_ => _.Jokes)
                .ToList();

            return categories;
        }

        public Category GetCategoryById(int id)
        {
            var category =_context.Categories
                .Include(_ => _.Jokes)
                .Where(_ => _.Id == id)
                .FirstOrDefault();
            
            return category;
        }

        public async Task<Category> CreateCategory(Category category)
        {
            try
            {
                if (category != null)
                {
                    var obj = _context.Add(category);
                    await _context.SaveChangesAsync();
                    return obj.Entity;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool CategoryExists(int id)
        {
            return _context.Categories.Any(e => e.Id == id);
        }
    }
}
