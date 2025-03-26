using NguyenQuangTrungRazorPages.Models;

namespace NguyenQuangTrungRazorPages.Repositories
{
    public interface ITagRepository
    {
       
           
            Task<List<Tag>> GetAllTagsAsync();
     
            

        Task<List<Tag>> GetTagsAsync();
        Task<List<Tag>> GetTagsByIdsAsync(List<int> tagIds);

    }
}
