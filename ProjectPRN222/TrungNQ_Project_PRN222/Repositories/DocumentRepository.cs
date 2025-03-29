using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using TrungNQ_Project_PRN222.DAL;
using TrungNQ_Project_PRN222.Models;

namespace TrungNQ_Project_PRN222.Repositories
{
    public class DocumentRepository : IDocumentRepository
    {
        private readonly InternalDocumentManagementContext _context;

        public DocumentRepository(InternalDocumentManagementContext context)
        {
            _context = context;
        }
        public void AddDocument(Document document)
        {
            if (document == null)
            {
                throw new ArgumentNullException(nameof(document), "Tài liệu không thể null.");
            }

            _context.Documents.Add(document);
            _context.SaveChanges();
        }

        public void DeleteByID(int id)
        {
            var finder = _context.Documents.FirstOrDefault(c => c.DocumentId == id);
            if (finder != null)
            {
                finder.DocumentStatusId = 5;
                _context.SaveChanges();
            }
        }

        public int DocumentCount()
        {
            return _context.Documents.Count();
        }

        public List<Document> GetAllDocumentActive()
        {
            return _context.Documents.Include(a => a.Account).Include(a => a.DocumentStatus).Include(a => a.Category).ToList();
        }

        public Document GetByID(int id)
        {
           return _context.Documents.FirstOrDefault(c => c.DocumentId == id);
        }

        public void UpdateDocument(Document document)
        {
            _context.Documents.Update(document);
            _context.SaveChanges();
        }
    }
}
