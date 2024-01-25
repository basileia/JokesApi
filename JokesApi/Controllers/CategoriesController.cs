﻿using Microsoft.AspNetCore.Mvc;
using JokesApi_BAL.Services;
using JokesApi_DAL.Entities;
using AutoMapper;
using JokesApi_BAL.Models;


namespace JokesApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ServiceCategory _serviceCategory;
        
        
        public CategoriesController(ServiceCategory serviceCategory)
        {
            _serviceCategory = serviceCategory;
            
        }

        // GET: api/Categories
        [HttpGet]
        public List<CategoryModel> GetAllCategories()
        {
            return _serviceCategory.GetAllCategories();
        }

        // lepší mít throw new Exception() v ServiceCategory nebo tady ActionResult (NotFound?) - business logic, nebo ještě jinak?
        // GET: api/Categories/5
        [HttpGet("{id}")]
        public ActionResult<CategoryModel> GetCategoryById(int id)
        {
            var category = _serviceCategory.GetCategoryById(id);

            if (category == null)
            {
                return NotFound("Invalid Id");
            }

            return category;
        }

        //// PUT: api/Categories/5
        //[HttpPut("{id}")]
        //public async Task<ActionResult> PutCategory(int id, CategoryDto category)
        //{
        //    var updateCategory = _mapper.Map<Category>(category);

        //    if (id != updateCategory.Id)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(updateCategory).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!CategoryExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}


        //// POST: api/Categories
        //[HttpPost]
        //public async Task<ActionResult<Category>> PostCategory(CategoryDto category)
        //{
        //    if (CategoryExists(category.Id))
        //    {
        //        return BadRequest("Category Id already exists.");
        //    }

        //    var newCategory = _mapper.Map<Category>(category);
        //    _context.Categories.Add(newCategory);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetCategory", new { id = newCategory.Id }, newCategory);
        //}

        //// DELETE: api/Categories/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteCategory(int id)
        //{
        //    var category = await _context.Categories.FindAsync(id);
        //    if (category == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Categories.Remove(category);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}

        //private bool CategoryExists(int id)
        //{
        //    return _context.Categories.Any(e => e.Id == id);
        //}


    }
}
