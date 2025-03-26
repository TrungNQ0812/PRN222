using NguyenQuangTrungRazorPages.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NguyenQuangTrungRazorPages.Repositories
{
    public interface INewsRepository
    {
        Task<List<NewsArticle>> GetAllAsync();
        Task<List<NewsArticle>> GetAllAsync(string? search = null, bool sortByIdAsc = true);
        Task<NewsArticle> GetByIdAsync(string id);
        Task CreateAsync(NewsArticle news);
        Task UpdateAsync(NewsArticle news);
        Task DeleteAsync(string id);
        Task<List<Category>> GetCategoriesAsync();
        Task<List<NewsArticle>> GetAllActiveAsync();
        Task<NewsArticle?> GetNewsByIdAsync(string newsArticleId);
      

    }
}
