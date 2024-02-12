using AutoMapper;

using JokesApi_BAL.Models;
using JokesApi_DAL.Contracts;
using JokesApi_DAL.Entities;
using Microsoft.AspNetCore.Http;

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
            
            if (category == null)
            {
                throw new BadHttpRequestException("Category not found");
            }
            
            CategoryModel categoryModel = _mapper.Map<Category, CategoryModel>(category);

            return categoryModel;
        }

        public async Task<Category> AddCategory(CategoryModel categoryModel)
        {
            if (_repositoryCategory.CategoryExists(categoryModel.Id))
             {
                throw new BadHttpRequestException("Category already exists.");
             }

            var category = _mapper.Map<Category>(categoryModel);

            return await _repositoryCategory.CreateCategory(category);            
        }

        public void UpdateCategory(int id, CategoryModel categoryModel)
        {
            if (id != categoryModel.Id)
            {
                throw new BadHttpRequestException("The id in the path must be the same as the category id.");
            }

            var existingCategory = GetCategoryById(id);

            if (existingCategory == null)
            {
                throw new BadHttpRequestException("Category not found");
            }

            var category = _mapper.Map<Category>(categoryModel);
            _repositoryCategory.Update(category);
        }

        public void DeleteCategory(int id)
        {
            var existingCategory = GetCategoryById(id);

            if (existingCategory == null)
            {
                throw new BadHttpRequestException("Category not found");
            }

            _repositoryCategory.Delete(id);
        }
    }
}
