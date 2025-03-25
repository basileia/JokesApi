using JokesApi_DAL.Entities;

namespace JokesApi_DAL.Contracts
{
    public interface IRepositoryCategory
    {
        List<Category> GetAllCategories();
        Category GetCategoryById(int id);
        Task<Category> CreateCategory(Category category);
        bool CategoryExists(int id);
        void Update(int id, string name);
        void Delete(int id);
    }
}
