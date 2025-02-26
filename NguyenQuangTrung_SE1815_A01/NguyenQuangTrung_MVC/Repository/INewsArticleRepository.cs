using NguyenQuangTrung_MVC.Models;

namespace NguyenQuangTrung_MVC.Repository
{
    public interface INewsArticleRepository
    {
        public List<NewsArticle> GetAllNewsArticlesActive();
        public void Add(NewsArticle newsArticle);

        public void deleteByID(int id);
        
    }
}
