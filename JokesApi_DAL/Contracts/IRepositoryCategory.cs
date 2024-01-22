using JokesApi_DAL.Entities;
using Microsoft.AspNetCore.Mvc;

namespace JokesApi_DAL.Contracts
{
    public interface IRepositoryCategory
    {
        Task<ActionResult<IEnumerable<Category>>> GetAllCategories();
        //Task<ActionResult<Category>> GetCategory(int id);
    }
}
