using AutoMapper;

using JokesApi_BAL.Models;
using JokesApi_BAL.Models.Category;
using JokesApi_DAL.Contracts;
using JokesApi_DAL.Entities;
using Microsoft.EntityFrameworkCore;

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
            var categories = _repositoryCategory.GetAll();            
            return _mapper.Map<List<CategoryModel>>(categories);
        }

        public Result<CategoryDetailModel, Error> GetCategoryById(int id)
        {
            var category = _repositoryCategory.GetCategoryById(id);
            
            if (category == null)
            {
                return CategoryErrors.CategoryNotFound;
            }
 
            return _mapper.Map<CategoryDetailModel>(category);
        }

        public Result<Category, Error> AddCategory(CreateCategoryModel categoryModel)
        {
            if (categoryModel == null)
                return CategoryErrors.CategoryIsEmpty;

            if (_repositoryCategory.GetByName(categoryModel.Name) != null)
                return CategoryErrors.CategoryExists;

            var category = _mapper.Map<Category>(categoryModel);
            return _repositoryCategory.Add(category);
        }

        public Result<CategoryDetailModel, Error> UpdateCategory(int id, CategoryModel categoryModel)
        {
            if (id != categoryModel.Id)
                return CategoryErrors.CategoryBadRequest;

            var existingCategory = GetCategoryById(id);
            if (existingCategory.Error != null)
                return CategoryErrors.CategoryNotFound;

            var categoryWithSameName = _repositoryCategory.GetByName(categoryModel.Name);
            if (categoryWithSameName != null && categoryWithSameName.Id != id)
                return CategoryErrors.CategoryExists;

            var category = _mapper.Map<Category>(categoryModel);
            _repositoryCategory.Update(category);

            return GetCategoryById(id);
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
