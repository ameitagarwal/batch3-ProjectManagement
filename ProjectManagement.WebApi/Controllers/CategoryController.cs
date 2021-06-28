using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProductManagement.Data.Entities;
using ProductManagement.Data.Services;
using ProductManagement.WebAPI.Helpers;
using ProjectManagement.WebApi.Models;
using System.Collections.Generic;

namespace ProjectManagement.WebApi.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    [Authorize]
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<CategoryController> _log;

        public CategoryController(ICategoryRepository categoryRepository, IMapper mapper, ILogger<CategoryController> log)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
            _log = log;
        }

        [HttpGet]
        public IActionResult GetAllCategories()
        {
            var categories = _categoryRepository.GetAllCategories();
            List<CategoryDto> cst = _mapper.Map<List<CategoryDto>>(categories);
            _log.LogInformation("GetAllCategories method is called");
            return Ok(cst);
        }

        [HttpGet("{categoryId}", Name = "CategoryById")]
        public IActionResult GetCategoryById(int categoryId)
        {
            var categories = _categoryRepository.GetCategoryById(categoryId);
            CategoryDto cst = _mapper.Map<CategoryDto>(categories);
            return Ok(cst);
        }

        [HttpPost]
        public IActionResult InsertCategory([FromBody] CategoryDto categoryObj)
        {
            Category cst = _mapper.Map<Category>(categoryObj);
            _categoryRepository.AddCategory(cst);
            return Ok();
        }

        [HttpPost("InsertList")]
        public IActionResult InsertCategories([FromBody] List<CategoryDto> categoryObj)
        {
            List<Category> cst = _mapper.Map<List<Category>>(categoryObj);
            _categoryRepository.AddCategoryList(cst);
            return Ok();
        }

        [HttpPut]
        public IActionResult UpdateCategory([FromBody] CategoryDto categoryObj)
        {
            Category cst = _mapper.Map<Category>(categoryObj);
            _categoryRepository.UpdateCategory(cst);
            return Ok();
        }

        [HttpDelete("{categoryId}")]
        public IActionResult DeleteCategory(int categoryId)
        {
            _categoryRepository.DeleteCategory(categoryId);
            return NoContent();
        }
    }
}
