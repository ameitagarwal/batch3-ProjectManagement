using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProductManagement.Data.Entities;
using ProductManagement.Data.Services;
using ProjectManagement.WebApi.Models;
using System.Collections.Generic;

namespace ProjectManagement.WebApi.Controllers
{
    [Route("api/category")]
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryController(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAllCategories()
        {
            var categories = _categoryRepository.GetAllCategories();
            List<CategoryDto> cst = _mapper.Map<List<CategoryDto>>(categories);
            return Ok(cst);
        }

        [HttpGet("{categoryId}")]
        public IActionResult GetCategoryById(int categoryId)
        {
            var categories = _categoryRepository.GetCategoryById(categoryId);
            CategoryDto cst = _mapper.Map<CategoryDto>(categories);
            return Ok(cst); s
        }

        [HttpPost]
        public IActionResult InsertCategory(CategoryDto categoryObj)
        {
            if (ModelState.IsValid)
            {
                Category cst = _mapper.Map<Category>(categoryObj);
                _categoryRepository.AddCategory(cst);
                return Ok();
            }
            else
            {
                return BadRequest();
            }

        }

        [HttpPost("InsertList")]
        public IActionResult InsertCategories(List<CategoryDto> categoryObj)
        {
            if (ModelState.IsValid)
            {
                Category cst = _mapper.Map<Category>(categoryObj);
                _categoryRepository.AddCategory(cst);
                return Ok();
            }
            else
            {
                return BadRequest();
            }

        }

        [HttpPut]
        public IActionResult UpdateCategory(CategoryDto categoryObj)
        {
            if (ModelState.IsValid)
            {
                Category cst = _mapper.Map<Category>(categoryObj);
                _categoryRepository.UpdateCategory(cst);
                return Ok();
            }
            else
            {
                return BadRequest();
            }

        }

        [HttpDelete]
        public IActionResult DeleteCategory(int categoryId)
        {
            _categoryRepository.DeleteCategory(categoryId);
            return NoContent();
        }
    }
}
