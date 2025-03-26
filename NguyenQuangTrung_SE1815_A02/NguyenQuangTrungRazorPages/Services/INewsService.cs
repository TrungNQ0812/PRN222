using NguyenQuangTrungRazorPages.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NguyenQuangTrungRazorPages.Services
{
    public interface INewsService
    {
        Task<List<NewsArticle>> GetAllAsync();
        Task<List<NewsArticle>> GetAllAsync(string search, bool sortByIdAsc);
        Task<NewsArticle> GetByIdAsync(string id);
        Task CreateAsync(NewsArticle news, short userId);
        Task UpdateAsync(NewsArticle news, List<int> tagIds, short userId);

        Task DeleteAsync(string id);
        Task<List<Category>> GetCategoriesAsync();
        Task<List<NewsArticle>> GetAllActiveAsync();
    }
}
