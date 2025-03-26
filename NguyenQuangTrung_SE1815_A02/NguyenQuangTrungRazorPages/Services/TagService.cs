using NguyenQuangTrungRazorPages.Models;
using NguyenQuangTrungRazorPages.Repositories;

namespace NguyenQuangTrungRazorPages.Services
{
    public class TagService : ITagService
    {
        private readonly ITagRepository _tagRepository;

        public TagService(ITagRepository tagRepository)
        {
            _tagRepository = tagRepository;
        }
        public async Task<List<Tag>> GetTagsAsync()
        {
            return await _tagRepository.GetTagsAsync();
        }
      

        public async Task<List<Tag>> GetAllTagsAsync()
        {
            return await _tagRepository.GetAllTagsAsync();
        }

        public async Task<List<Tag>> GetTagsByIdsAsync(List<int> tagIds)
        {
            return await _tagRepository.GetTagsByIdsAsync(tagIds);
        }

       


       
    }

}
