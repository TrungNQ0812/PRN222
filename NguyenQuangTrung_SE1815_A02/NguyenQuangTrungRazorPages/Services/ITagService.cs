using NguyenQuangTrungRazorPages.Models;

namespace NguyenQuangTrungRazorPages.Services
{
    public interface ITagService
    {
        Task<List<Tag>> GetAllTagsAsync();
        Task<List<Tag>> GetTagsByIdsAsync(List<int> tagIds);
      
       
        Task<List<Tag>> GetTagsAsync();
    }

}
