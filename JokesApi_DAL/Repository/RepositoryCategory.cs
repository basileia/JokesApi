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
            Console.WriteLine("Je v repository?");
            _context = context;
        }
                       
        public async Task<ActionResult<IEnumerable<Category>>> GetAllCategories()
        {
            var categories = await _context.Categories
                .Include(_ => _.Jokes)
                .ToListAsync();

            return categories;
        }

        //public async Task<ActionResult<Category>> GetCategory(int id)
        //{
        //    var category = await _context.Categories
        //        .Include(_ => _.Jokes)
        //        .Where(_ => _.Id == id)
        //        .FirstOrDefaultAsync();

        //    if (category == null)
        //    {
        //        return NotFound();
        //    }

        //    return category;
        //}
    }
}
