using TrungNQ_Project_PRN222.Models;

namespace TrungNQ_Project_PRN222.Repositories
{
    public interface IDocumentRepository
    {
        public List<Document> GetAllDocumentActive();
        public void AddDocument(Document document);
        public void UpdateDocument(Document document);
        public void DeleteByID(int id);
        public Document GetByID(int id);
        public int DocumentCount();
    }

}
