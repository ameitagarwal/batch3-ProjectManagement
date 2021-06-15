using ProductManagement.Data.Entities;
using System.Collections.Generic;
using System.Linq;

namespace ProductManagement.Data.Services
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ProductDbContext _context;

        public CategoryRepository(ProductDbContext context)
        {
            _context = context;
        }

        public bool AddCategory(Category Category)
        {
            _context.Categories.Add(Category);
            return SaveChanges();
        }

        public bool AddCategoryList(List<Category> Categorys)
        {
            _context.Categories.AddRange(Categorys);
            return SaveChanges();
        }
        public bool UpdateCategoryList(List<Category> Categorys)
        {
            _context.Categories.UpdateRange(Categorys);
            return SaveChanges();
        }
        public bool UpdateCategory(Category Category)
        {
            _context.Categories.Update(Category);
            return SaveChanges();
        }
        public bool DeleteCategory(int CategoryId)
        {
            var Category = GetCategoryById(CategoryId);
            if (Category != null)
            {
                _context.Categories.Remove(Category);
                return SaveChanges();
            }
            return true;
        }
        public List<Category> GetAllCategories()
        {
            return _context.Categories
                .ToList();
        }

        public Category GetCategoryById(int CategoryId)
        {
            // var a = _context.Categories.First(a => a.CategoryId == CategoryId); // Code Breaks since no record exists
            // var b = _context.Categories.FirstOrDefault(a => a.CategoryId == CategoryId); // Doesn't break , since it takes default value
            // var c = _context.Categories.Single(a => a.CategoryId == CategoryId); // Code Breaks since no record exists
            // var f = _context.Categories.SingleOrDefault(a => a.CategoryId == CategoryId); // Doesn't break , since it takes default value
            // var d = _context.Categories.Where(a => a.CategoryId == CategoryId).FirstOrDefault();
            // var e = _context.Categories.Find(2);

            // var g = _context.Categories.Single(a => a.Name == "Mobile"); // Code Breaks since more than 1 record exists
            var h = _context.Categories.SingleOrDefault(a => a.Name == "Mobile"); // Code Breaks since more than 1 record exists
            return _context.Categories.FirstOrDefault(a => a.CategoryId == CategoryId);
        }

        private bool SaveChanges()
        {
            if (_context.SaveChanges() > 0)
            {
                return true;
            };
            return false;
        }
    }
}
