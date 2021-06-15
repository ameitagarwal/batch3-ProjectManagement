using ProductManagement.Data.Entities;
using System.Collections.Generic;

namespace ProductManagement.Data.Services
{
    public interface ICategoryRepository
    {
        bool AddCategory(Category Category);
        bool AddCategoryList(List<Category> Categorys);
        bool UpdateCategory(Category Category);
        bool DeleteCategory(int CategoryId);
        List<Category> GetAllCategories();
        Category GetCategoryById(int CategoryId);
    }
}
