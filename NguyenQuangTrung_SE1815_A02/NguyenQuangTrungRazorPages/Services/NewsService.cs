using NguyenQuangTrungRazorPages.Models;
using NguyenQuangTrungRazorPages.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NguyenQuangTrungRazorPages.Services
{
    public class NewsService : INewsService
    {
        private readonly INewsRepository _newsRepository;
        private readonly ITagService _tagService;

        public NewsService(INewsRepository newsRepository, ITagService tagService)
        {
            _newsRepository = newsRepository;
            _tagService = tagService;
        }

        public async Task<List<NewsArticle>> GetAllAsync()
        {
            return await _newsRepository.GetAllAsync();
        }
        public async Task<List<NewsArticle>> GetAllAsync(string search , bool sortByIdAsc)
        {
            return await _newsRepository.GetAllAsync(search, sortByIdAsc);
        }
        public async Task<List<NewsArticle>> GetAllActiveAsync()
        {
            return await _newsRepository.GetAllActiveAsync();
        }

        public async Task<NewsArticle> GetByIdAsync(string id)
        {
            return await _newsRepository.GetByIdAsync(id);
        }
       
        public async Task CreateAsync(NewsArticle news, short userId)
        {
        //    news.NewsArticleId = Guid.NewGuid().ToString(); // Tạo ID duy nhất
            news.CreatedDate = DateTime.UtcNow;
            news.ModifiedDate = DateTime.UtcNow;
            news.CreatedById = userId;
            news.UpdatedById = userId;
            news.NewsStatus = true; // Mặc định là Active (1)

            // Kiểm tra nếu CategoryId có tồn tại trong database
            

            await _newsRepository.CreateAsync(news);
        }



        public async Task UpdateAsync(NewsArticle news, List<int> tagIds, short userId)
        {
            var existingNews = await _newsRepository.GetByIdAsync(news.NewsArticleId);
            if (existingNews != null)
            {
                existingNews.NewsTitle = news.NewsTitle;
                existingNews.Headline = news.Headline;
                existingNews.NewsContent = news.NewsContent;
                existingNews.NewsSource = news.NewsSource;
                existingNews.NewsStatus = news.NewsStatus;
                existingNews.CategoryId = news.CategoryId;
                existingNews.UpdatedById = userId;
                existingNews.ModifiedDate = DateTime.UtcNow;

                // ✅ Cập nhật danh sách Tags
                existingNews.Tags.Clear();
                var newTags = await _tagService.GetTagsByIdsAsync(tagIds);
                foreach (var tag in newTags)
                {
                    existingNews.Tags.Add(tag);
                }

                await _newsRepository.UpdateAsync(existingNews);
            }
        }




        public async Task DeleteAsync(string id)
        {
            await _newsRepository.DeleteAsync(id);
        }

        public async Task<List<Category>> GetCategoriesAsync()
        {
            return await _newsRepository.GetCategoriesAsync();
        }
       

       

    }
}
