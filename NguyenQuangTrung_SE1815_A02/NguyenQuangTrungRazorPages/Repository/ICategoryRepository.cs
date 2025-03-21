using Microsoft.AspNetCore.Mvc.Rendering;
using NguyenQuangTrungRazorPages.Models;

namespace NguyenQuangTrungRazorPages.Repository
{
    public interface ICategoryRepository
    {
        public List<Category> GetAll();
        public List<SelectListItem> GetAllCategoryID();
    }
}
