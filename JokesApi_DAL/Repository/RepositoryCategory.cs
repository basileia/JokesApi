using JokesApi_DAL.Contracts;
using JokesApi_DAL.Data;
using JokesApi_DAL.Entities;
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
                .AsNoTracking()
                .FirstOrDefault();
            
            return category;
        }

        public async Task<Category> CreateCategory(Category category)
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

        public void Update(int id, string name)
        {
            _context.Categories
                .Where(_ => _.Id == id)
                .ExecuteUpdate(_ => _.SetProperty(u => u.Name, name));

            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var category = _context.Categories.Find(id);
            if (category != null)
            {
                _context.Categories.Remove(category);
                _context.SaveChanges();
            }
        }

        public bool CategoryExists(int id)
        {
            return _context.Categories.Any(e => e.Id == id);
        }
    }
}
