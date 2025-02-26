using Microsoft.AspNetCore.Mvc.Rendering;
using NguyenQuangTrung_MVC.Models;

namespace NguyenQuangTrung_MVC.Repository
{
    public interface ICategoryRepository
    {
        public List<Category> GetAll();
        public List<SelectListItem> GetAllCategoryID();
    }
}
