using Microsoft.AspNetCore.Http.HttpResults;
using NguyenQuangTrung_MVC.DAL;
using NguyenQuangTrung_MVC.Models;

namespace NguyenQuangTrung_MVC.Repository
{
    public class NewsArticleRepository : INewsArticleRepository
    {
        private readonly FuNewsManagementContext _context;

        // Inject DbContext vào Repository
        public NewsArticleRepository(FuNewsManagementContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void Add(NewsArticle newsArticle)
        {
            _context.NewsArticles.Add(newsArticle);
            _context.SaveChanges();
        }

        public void deleteByID(int id)
        {
           NewsArticle finder =  _context.NewsArticles.FirstOrDefault(a => Convert.ToInt32(a.NewsArticleId) == id);
           finder.NewsStatus = false;
            _context.SaveChanges();
        }

        public List<NewsArticle> GetAllNewsArticlesActive()
        {
            return _context.NewsArticles.Where(a => a.NewsStatus == true).ToList();
        }

        public NewsArticle GetNewsById(int? id)
        {
            if (!id.HasValue)
            {
                return null;
            }
            var news = _context.NewsArticles.FirstOrDefault(a => Convert.ToInt32(a.NewsArticleId) == id);
            return news;
        }

        public void Update(NewsArticle newsArticle)
        {
            _context.NewsArticles.Update(newsArticle);
            _context.SaveChanges();
        }

    }
}
