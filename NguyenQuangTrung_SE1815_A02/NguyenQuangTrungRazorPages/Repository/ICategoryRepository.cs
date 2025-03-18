using Microsoft.AspNetCore.Mvc.Rendering;
using NguyenQuangTrungRazorPages.Models;

namespace NguyenQuangTrungRazorPages.Repository
{
    public interface ICategoryRepository
    {

        public List<Category> GetAllCategories();
        public void AddCategory(Category category);
        public void UpdateCategory(Category category);
        public void DeleteCategory(int id);
        public List<SelectListItem> GetAllCategoryID();

    }
}
