using AutoMapper;

using JokesApi_BAL.Models;
using JokesApi_DAL.Contracts;
using JokesApi_DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace JokesApi_BAL.Services
{
    public class ServiceCategory
    {
        private readonly IRepositoryBase<Category> _repositoryCategory;
        private readonly IMapper _mapper;

        public ServiceCategory(IRepositoryBase<Category> repositoryCategory, IMapper mapper)
        {
            _repositoryCategory = repositoryCategory;
            _mapper = mapper;            
        }

        public List<CategoryModel> GetAllCategories()
        {
            List<Category> categories = _repositoryCategory.GetAll();
            List<CategoryModel> categoriesModel = _mapper.Map<List<Category>, List<CategoryModel>>(categories);

            return categoriesModel;
        }

        public Result<CategoryModel, Error> GetCategoryById(int id)
        {
            Category category = _repositoryCategory.GetById(id);
            
            if (category == null)
            {
                return CategoryErrors.CategoryNotFound;
            }
            
            CategoryModel categoryModel = _mapper.Map<Category, CategoryModel>(category);

            return categoryModel;
        }

        public Result<Category, Error> AddCategory(CategoryModel categoryModel)
        {
            if (_repositoryCategory.GetById(categoryModel.Id) != null)
             {
                return CategoryErrors.CategoryExists;
             }

            var category = _mapper.Map<Category>(categoryModel);
            
            return _repositoryCategory.Add(category);
        }

        public Result<CategoryModel, Error> UpdateCategory(int id, CategoryModel categoryModel)
        {
            if (id != categoryModel.Id)
            {
                return CategoryErrors.CategoryBadRequest;
            }

            var existingCategory = GetCategoryById(id);

            if (existingCategory.Error != null)
            {
                return CategoryErrors.CategoryNotFound;
            }

            var category = _mapper.Map<Category>(categoryModel);
            
           _repositoryCategory.Update(category);

            var updatedCategory = GetCategoryById(id);

            return updatedCategory;
        }

        public Result<bool, Error> DeleteCategory(int id)
        {
            var existingCategory = GetCategoryById(id);

            if (existingCategory.Error != null)
            {
                return CategoryErrors.CategoryNotFound;
            }

            _repositoryCategory.Delete(_repositoryCategory.GetById(id));

            return true;
        }
    }
}
