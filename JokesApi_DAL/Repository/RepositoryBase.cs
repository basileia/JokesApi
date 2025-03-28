using JokesApi_DAL.Contracts;
using JokesApi_DAL.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace JokesApi_DAL.Repository
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected readonly AppDbContext _context;
        private readonly DbSet<T> _dbSet;

        public RepositoryBase(AppDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public T GetById(int id)
        {
            return _dbSet.Find(id);
        }

        public List<T> GetAll()
        {
            
            return _dbSet.ToList();
        }

        public T Add(T entity)
        {
            var obj = _context.Add(entity);
            _context.SaveChanges();
            return obj.Entity;
        }

        public void Update(T entity)
        {
            _context.ChangeTracker.Clear();
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();            
        }

        public void Delete(int id)
        {
            var entity = _dbSet.Find(id);
            if (entity != null)
            {
                _dbSet.Remove(entity);
                _context.SaveChanges();
            }
        }

        public T GetByProperty(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.FirstOrDefault(predicate);
        }
    }
}
