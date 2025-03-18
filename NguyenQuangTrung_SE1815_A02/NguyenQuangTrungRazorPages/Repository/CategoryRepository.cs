using Microsoft.AspNetCore.Mvc.Rendering;
using NguyenQuangTrungRazorPages.DAL;
using NguyenQuangTrungRazorPages.Models;

namespace NguyenQuangTrungRazorPages.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private FuNewsManagementContext context;

        public CategoryRepository(FuNewsManagementContext context)
        {
            this.context = context;
        }

        public void AddCategory(Category category)
        {
            throw new NotImplementedException();
        }

        public void DeleteCategory(int id)
        {
            throw new NotImplementedException();
        }

        public List<Category> GetAllCategories()
        {
            return context.Categories.ToList();
        }

        public List<SelectListItem> GetAllCategoryID()
        {
            return context.Categories.Select(c => new SelectListItem { 
                Value = c.CategoryId.ToString(),
                Text = c.CategoryName.ToString(),
            }).ToList();
        }

        public void UpdateCategory(Category category)
        {
            throw new NotImplementedException();
        }
    }
}
