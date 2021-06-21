using Microsoft.AspNetCore.Mvc;
using ProductManagement.Data.Entities;
using ProductManagement.Data.Services;
using ProductManagement.MVC.Models;

namespace ProductManagement.MVC.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public IActionResult Index()
        {
            var categories = _categoryRepository.GetAllCategories();
            return View(categories);
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
                Category cst = new Category
                {
                    CategoryId = categoryObj.CategoryId,
                    Name = categoryObj.Name,
                    Description = categoryObj.Description,
                };
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
