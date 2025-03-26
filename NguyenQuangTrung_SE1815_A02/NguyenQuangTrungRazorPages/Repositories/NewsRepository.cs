using Microsoft.EntityFrameworkCore;
using NguyenQuangTrungRazorPages.DAL;
using NguyenQuangTrungRazorPages.Models;
using NuGet.Packaging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NguyenQuangTrungRazorPages.Repositories
{
    public class NewsRepository : INewsRepository
    {
        private readonly FuNewsManagementContext _context;

        public NewsRepository(FuNewsManagementContext context)
        {
            _context = context;
        }

        public async Task<List<NewsArticle>> GetAllAsync()
        {
            return await _context.NewsArticles.Include(n => n.Category).Include(n => n.Tags).ToListAsync();
        }
        public async Task<List<NewsArticle>> GetAllAsync(string? search = null, bool sortByIdAsc = true)
        {
            var query = _context.NewsArticles
                .Include(n => n.Category)
                .Include(n => n.Tags) // 🆕 Load danh sách Tags
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(search))
            {
                query = query.Where(n => n.NewsTitle.Contains(search));
            }

            query = sortByIdAsc ? query.OrderBy(n => n.NewsArticleId) : query.OrderByDescending(n => n.NewsArticleId);

            return await query.ToListAsync();
        }


        public async Task<List<NewsArticle>> GetAllActiveAsync()
        {
            return await _context.NewsArticles
                .Where(n => n.NewsStatus == true) // Lọc bài viết có NewsStatus = 1 (Active)
                  .Include(n => n.Tags)
                .Include(n => n.Category) // Nạp thông tin danh mục
                .ToListAsync();
        }

        public async Task<NewsArticle?> GetByIdAsync(string id)
        {
            return await _context.NewsArticles.Include(n => n.Tags).FirstOrDefaultAsync(n => n.NewsArticleId == id);
        }
        public async Task CreateAsync(NewsArticle news)
        {
            _context.NewsArticles.Add(news);
            await _context.SaveChangesAsync();
        }




        public async Task UpdateAsync(NewsArticle news)
        {
            _context.NewsArticles.Update(news);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(string id)
        {
            var news = await _context.NewsArticles
                .Include(n => n.Tags) // Load luôn Tags để có thể xóa quan hệ
                .FirstOrDefaultAsync(n => n.NewsArticleId == id);

            if (news != null)
            {
                // Xóa tất cả các liên kết trong bảng trung gian NewsTag
                news.Tags.Clear();

                _context.NewsArticles.Remove(news);
                await _context.SaveChangesAsync();
            }
        }



        public async Task<List<Category>> GetCategoriesAsync()
        {
            return await _context.Categories.ToListAsync();
        }
       


        public async Task<NewsArticle?> GetNewsByIdAsync(string newsArticleId)
        {
            return await _context.NewsArticles.Include(n => n.Tags)
                                              .FirstOrDefaultAsync(n => n.NewsArticleId == newsArticleId);
        }

       

    }
}
