using AutoMapper;

using JokesApi_BAL.Models;
using JokesApi_DAL.Contracts;
using JokesApi_DAL.Entities;
using Microsoft.AspNetCore.Mvc;
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
            List<Category> categories = _repositoryCategory.GetAllCategories();
            List<CategoryModel> categoriesModel = _mapper.Map<List<Category>, List<CategoryModel>>(categories);

            return categoriesModel;
        }

        public CategoryModel GetCategoryById(int id)
        {
            Category category = _repositoryCategory.GetCategoryById(id);
            CategoryModel categoryModel = _mapper.Map<Category, CategoryModel>(category);

            return categoryModel;
        }

        public async Task<Category> AddCategory(CategoryModel categoryModel)
        {
            var category = _mapper.Map<Category>(categoryModel);
            
             if (_repositoryCategory.CategoryExists(category.Id))
            {
                throw new Exception("Category Id already exists.");
            }

            if (category == null)
            {
                throw new ArgumentNullException(nameof(category));
            }
            else
            {
                return await _repositoryCategory.CreateCategory(category);
            }
        }

        public void UpdateCategory(CategoryModel categoryModel)
        {
            if (categoryModel == null)
            {
                throw new ArgumentNullException(nameof(categoryModel));
            }

            var category = _mapper.Map<Category>(categoryModel);
            _repositoryCategory.Update(category);

        }


    }
}
