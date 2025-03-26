using NguyenQuangTrungRazorPages.Models;

namespace NguyenQuangTrungRazorPages.Repositories
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetAllAsync();
        Task<Category?> GetByIdAsync(short id);
        Task CreateAsync(Category category);
        Task UpdateAsync(Category category);
        Task DeleteAsync(short id);
        Task<List<Category>> GetAllCategoryAsync(string? search = null, bool sortByIdAsc = true);
        Task<List<Category>> GetAllCategoryAsync();
    }
}
