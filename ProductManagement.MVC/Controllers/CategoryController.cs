using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProductManagement.Data.Entities;
using ProductManagement.Data.Services;
using ProductManagement.MVC.Models;
using System.Collections.Generic;

namespace ProductManagement.MVC.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryController(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        [Authorize]
        public IActionResult Index()
        {
            var categories = _categoryRepository.GetAllCategories();
            List<CategoryDto> cst = _mapper.Map<List<CategoryDto>>(categories);
            return View(cst);
        }

        [HttpGet]
        public IActionResult AddOrEdit(int categoryId)
        {
            if (categoryId > 0)
            {
                var category = _categoryRepository.GetCategoryById(categoryId);
                return View(category);
            }
            else
            {
                return View();
            }
        }

        [HttpPost]
        public IActionResult AddOrEdit(CategoryDto categoryObj)
        {
            if (ModelState.IsValid)
            {
                //Category cst = new Category
                //{
                //    CategoryId = categoryObj.CategoryId,
                //    Name = categoryObj.Name,
                //    Description = categoryObj.Description,
                //};
                Category cst = _mapper.Map<Category>(categoryObj);
                if (categoryObj.CategoryId == 0)
                {
                    _categoryRepository.AddCategory(cst);
                }
                else
                {
                    _categoryRepository.UpdateCategory(cst);
                }
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }

        }

        public IActionResult Delete(int categoryId)
        {
            _categoryRepository.DeleteCategory(categoryId);
            return RedirectToAction("Index");
        }

    }
}
