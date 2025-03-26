using NguyenQuangTrungRazorPages.Models;

namespace NguyenQuangTrungRazorPages.Repositories
{
    public interface IAccountRepository
    {
        Task<SystemAccount?> GetAccountByEmailAsync(string email);
        Task<List<SystemAccount>> GetAllAsync(string? search = null, bool sortByIdAsc = true);
        Task<SystemAccount?> GetByIdAsync(short id);
        Task AddAsync(SystemAccount account);
        Task UpdateAsync(SystemAccount account);
        Task DeleteAsync(short id);
    }

}
