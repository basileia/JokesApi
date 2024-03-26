﻿using Microsoft.AspNetCore.Mvc;
using JokesApi_BAL.Services;
using JokesApi_DAL.Entities;
using JokesApi_BAL.Models;

namespace JokesApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CategoriesController : BaseController
    {
        private readonly ServiceCategory _serviceCategory;
                
        public CategoriesController(ServiceCategory serviceCategory)
        {
            _serviceCategory = serviceCategory;            
        }

        [HttpGet]
        public ActionResult<List<CategoryModel>> GetAllCategories()
        {
            return _serviceCategory.GetAllCategories();
        }

        [HttpGet("{id}")]
        public ActionResult<CategoryModel> GetCategoryById(int id)
        {
            return GetResponse(_serviceCategory.GetCategoryById(id));
        }
 
        [HttpPost]
        public ActionResult<Category> CreateCategory(CategoryModel categoryModel)
        {         
            return GetResponse(_serviceCategory.AddCategory(categoryModel));
        }

        [HttpPut("{id}")]
        public ActionResult<CategoryModel> PutCategory(int id, CategoryModel categoryModel)
        {
            return GetResponse(_serviceCategory.UpdateCategory(id, categoryModel));
        }               

        [HttpDelete("{id}")]
        public ActionResult<bool> DeleteCategory(int id)
        {
            return GetResponse(_serviceCategory.DeleteCategory(id));
        }        
    }
}
