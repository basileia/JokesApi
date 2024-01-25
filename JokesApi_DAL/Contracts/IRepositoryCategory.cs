using JokesApi_DAL.Entities;
using Microsoft.AspNetCore.Mvc;

namespace JokesApi_DAL.Contracts
{
    public interface IRepositoryCategory
    {
        List<Category> GetAllCategories();
        Category GetCategoryById(int id);
    }
}
