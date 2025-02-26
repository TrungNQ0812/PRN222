using Microsoft.AspNetCore.Mvc.Rendering;
using NguyenQuangTrung_MVC.DAL;
using NguyenQuangTrung_MVC.Models;

namespace NguyenQuangTrung_MVC.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly FuNewsManagementContext _context;

        public CategoryRepository(FuNewsManagementContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public List<Category> GetAll()
        {
            return _context.Categories.ToList();
        }

        public List<SelectListItem> GetAllCategoryID()
        {
            
            return _context.Categories.Select(c => new SelectListItem
            {
                Value = c.CategoryId.ToString(),
                Text = c.CategoryName.ToString()
            }).ToList();
        }
    }
}
