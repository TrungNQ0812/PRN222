using TrungNQ_Project_PRN222.DAL;
using TrungNQ_Project_PRN222.Models;

namespace TrungNQ_Project_PRN222.Repositories
{
    public class DocumentStatusRepository : IDocumentStatusRepository
    {

        private readonly InternalDocumentManagementContext _context;

        public DocumentStatusRepository(InternalDocumentManagementContext context)
        {
            _context  = context;
        }

        public List<DocumentStatus> GetAllDocumentStatus()
        {
            return _context.DocumentStatuses.ToList();
        }
    }
}
