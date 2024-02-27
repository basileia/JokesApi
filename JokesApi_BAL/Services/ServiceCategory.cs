using AutoMapper;

using JokesApi_BAL.Models;
using JokesApi_DAL.Contracts;
using JokesApi_DAL.Entities;
using System.Diagnostics.Tracing;

namespace JokesApi_BAL.Services
{
    public class ServiceCategory
    {
        private readonly IRepositoryCategory _repositoryCategory;
        private readonly IMapper _mapper;

        public ServiceCategory(IRepositoryCategory repositoryCategory, IMapper mapper)
        {
            _repositoryCategory = repositoryCategory;
            _mapper = mapper;            
        }

        public List<CategoryModel> GetAllCategories()
        {
            List<Category> categories = _repositoryCategory.GetAllCategories();
            List<CategoryModel> categoriesModel = _mapper.Map<List<Category>, List<CategoryModel>>(categories);

            return categoriesModel;
        }

        public Result<CategoryModel, Error> GetCategoryById(int id)
        {
            Category category = _repositoryCategory.GetCategoryById(id);
            
            if (category == null)
            {
                return CategoryErrors.CategoryNotFound;
            }
            
            CategoryModel categoryModel = _mapper.Map<Category, CategoryModel>(category);

            return categoryModel;
        }

        public async Task<Result<Category, Error>> AddCategory(CategoryModel categoryModel)
        {
            if (_repositoryCategory.CategoryExists(categoryModel.Id))
             {
                return CategoryErrors.CategoryExists;
             }

            var category = _mapper.Map<Category>(categoryModel);

            return await _repositoryCategory.CreateCategory(category);            
        }

        public Result<CategoryModel, Error> UpdateCategory(int id, string name)
        {
            var existingCategory = GetCategoryById(id);

            if (existingCategory.Error != null)
            {
                return CategoryErrors.CategoryNotFound;
            }

            _repositoryCategory.Update(id, name);

            return GetCategoryById(id);
        }

        public Result<Category, Error>? DeleteCategory(int id)
        {
            var existingCategory = GetCategoryById(id);

            if (existingCategory.Error != null)
            {
                return CategoryErrors.CategoryNotFound;
            }

            _repositoryCategory.Delete(id);

            return null;
        }
    }
}
