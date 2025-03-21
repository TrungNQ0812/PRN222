using NguyenQuangTrungRazorPages.Models;

namespace NguyenQuangTrungRazorPages.Repository
{
    public interface INewsArticleRepository
    {
        public List<NewsArticle> GetAllNewsArticlesActive();
        public void Add(NewsArticle newsArticle);

        public void deleteByID(int id);
        
    }
}
