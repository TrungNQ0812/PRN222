using NguyenQuangTrungRazorPages.Models;
using NguyenQuangTrungRazorPages.Repositories;

namespace NguyenQuangTrungRazorPages.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

      
        public async Task<List<Category>> GetAllCategoryAsync(string search, bool sortByIdAsc)
        {
            return await _categoryRepository.GetAllCategoryAsync(search, sortByIdAsc);
        }
        public async Task<List<Category>> GetAllCategoryAsync()
        {
            return await _categoryRepository.GetAllCategoryAsync();
        }


        public async Task<Category?> GetByIdAsync(short id)
        {
            return await _categoryRepository.GetByIdAsync(id);
        }

        public async Task CreateAsync(Category category)
        {
            await _categoryRepository.CreateAsync(category);
        }

        public async Task UpdateAsync(Category category)
        {
            await _categoryRepository.UpdateAsync(category);
        }

        public async Task DeleteAsync(short? id)
        {
            await _categoryRepository.DeleteAsync(id);
        }
    }
    }
