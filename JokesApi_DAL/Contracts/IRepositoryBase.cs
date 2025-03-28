using System.Linq.Expressions;

namespace JokesApi_DAL.Contracts
{
    public interface IRepositoryBase<T> where T : class
    {
        List<T> GetAll();
        T GetById(int id);
        T Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        T GetByProperty(Expression<Func<T, bool>> predicate);
    }
}
