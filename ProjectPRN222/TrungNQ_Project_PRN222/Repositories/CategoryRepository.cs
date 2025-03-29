using TrungNQ_Project_PRN222.DAL;
using TrungNQ_Project_PRN222.Models;

namespace TrungNQ_Project_PRN222.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly InternalDocumentManagementContext _context;

        public CategoryRepository(InternalDocumentManagementContext context)
        {
            _context = context;
        }

        public List<Category> loadAllCategory()
        {
            return _context.Categories.ToList();
        }
    }
}
