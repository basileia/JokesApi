namespace JokesApi_DAL.Contracts
{
    public interface IRepositoryBase<T>
    {
        IEnumerable<T> GetAll();
        T GetById(int id);
        Task<T> Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        bool Exists(int id);
    }
}
