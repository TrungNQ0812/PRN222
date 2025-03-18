using NguyenQuangTrungRazorPages.Models;

namespace NguyenQuangTrungRazorPages.Repository
{
    public interface INewsRepository
    {
        public List<NewsArticle> GetAllNewsArticles();
        public void Add(NewsArticle newsArticle);

        public void deleteByID(int id);
    }
}
