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
        private readonly Mapper _mapper;

        public ServiceCategory(IRepositoryCategory repositoryCategory)
        {
            _repositoryCategory = repositoryCategory;
            var _configCategory = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Category, CategoryModel>();
                cfg.CreateMap<Joke, JokeModel>();
            });
            _mapper = new Mapper(_configCategory);
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
    }
}
