using Microsoft.AspNetCore.Mvc;
using ProductManagement.Data.Services;

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
            var categories = _categoryRepository.GetCategoryById(5);
            return View();
        }
    }
}
