using JokesApi_DAL.Entities;

namespace JokesApi_DAL.Contracts
{
    public interface IRepositoryCategory : IRepositoryBase<Category>
    {
        Category GetCategoryById(int id);
        Task<Category> CreateCategory(Category category);
        bool CategoryExists(int id);
        void Update(int id, string name);
        void Delete(int id);
        Category GetByName(string name);
    }
}
