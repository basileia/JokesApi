﻿using JokesApi_DAL.Contracts;
using JokesApi_DAL.Data;
using JokesApi_DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace JokesApi_DAL.Repository
{
    public class RepositoryCategory : RepositoryBase<Category>, IRepositoryCategory
    {
        public RepositoryCategory(AppDbContext context) : base(context) { }

        
        public Category GetCategoryById(int id)
        {
            var category =_context.Categories
                .Include(_ => _.Jokes)
                .Where(_ => _.Id == id)
                .AsNoTracking()
                .FirstOrDefault();
            
            return category;
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

        public Category GetByName(string name)
        {
            return GetByProperty(c => c.Name == name);
        }
    }
}
