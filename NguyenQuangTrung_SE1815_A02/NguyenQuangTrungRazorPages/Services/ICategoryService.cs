using NguyenQuangTrungRazorPages.Models;

namespace NguyenQuangTrungRazorPages.Services
{
    public interface ICategoryService
    {
        Task<List<Category>> GetAllCategoryAsync(string search, bool sortByIdAsc);
        Task<List<Category>> GetAllCategoryAsync();
        Task<Category?> GetByIdAsync(short id);
        Task CreateAsync(Category category);
        Task UpdateAsync(Category category);
        Task DeleteAsync(short? id);
    }
}
