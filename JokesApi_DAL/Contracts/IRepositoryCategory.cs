using JokesApi_DAL.Entities;

namespace JokesApi_DAL.Contracts
{
    public interface IRepositoryCategory : IRepositoryBase<Category>
    {
        Category GetCategoryById(int id);
        bool CategoryExists(int id);
        Category GetByName(string name);
    }
}
