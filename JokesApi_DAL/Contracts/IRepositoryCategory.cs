using JokesApi_DAL.Entities;

namespace JokesApi_DAL.Contracts
{
    public interface IRepositoryCategory
    {
        List<Category> GetAllCategories();
        Category GetCategoryById(int id);
        Task<Category> CreateCategory(Category category);
        bool CategoryExists(int id);
        void Update(Category category);
        void Delete(int id);
    }
}
