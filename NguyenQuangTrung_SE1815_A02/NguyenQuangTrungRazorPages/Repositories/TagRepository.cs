using Microsoft.EntityFrameworkCore;
using NguyenQuangTrungRazorPages.DAL;
using NguyenQuangTrungRazorPages.Models;
using NuGet.Packaging;

namespace NguyenQuangTrungRazorPages.Repositories
{
    public class TagRepository : ITagRepository
    {
        private readonly FuNewsManagementContext _context;

        public TagRepository(FuNewsManagementContext context)
        {
            _context = context;
        }


        public async Task<List<Tag>> GetTagsAsync()
        {
            return await _context.Tags.ToListAsync();
        }

        

        public async Task<List<Tag>> GetAllTagsAsync()
        {
            return await _context.Tags.ToListAsync();
        }

        public async Task<List<Tag>> GetTagsByIdsAsync(List<int> tagIds)
        {
            return await _context.Tags.Where(t => tagIds.Contains(t.TagId)).ToListAsync();
        }

       


      
        

       

    }



}


