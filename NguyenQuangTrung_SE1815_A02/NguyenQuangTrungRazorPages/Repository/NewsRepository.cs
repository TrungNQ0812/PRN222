using NguyenQuangTrungRazorPages.DAL;
using NguyenQuangTrungRazorPages.Models;

namespace NguyenQuangTrungRazorPages.Repository
{
    public class NewsRepository : INewsRepository
    {
        private readonly FuNewsManagementContext _context;

        // Inject DbContext vào Repository
        public NewsRepository(FuNewsManagementContext context)
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
            NewsArticle finder = _context.NewsArticles.FirstOrDefault(a => Convert.ToInt32(a.NewsArticleId) == id);
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


        public int NewsCount()
        {
            return _context.NewsArticles.Count();
        }

        public List<NewsArticle> GetAllNewsArticles()
        {
            throw new NotImplementedException();
        }
    }
}
