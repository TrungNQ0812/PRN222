using NguyenQuangTrungRazorPages.Models;

namespace NguyenQuangTrungRazorPages.Services
{
    public interface IAccountService
    {
        Task<SystemAccount?> AuthenticateAsync(string email, string password);
        Task<List<SystemAccount>> GetAllAsync(string? search = null, bool sortByIdAsc = true);
        Task<SystemAccount?> GetByIdAsync(short id);
        Task AddAsync(SystemAccount account);
        Task UpdateAsync(SystemAccount account);
        Task DeleteAsync(short id);
        Task<SystemAccount?> GetProfileAsync(short accountId);
        Task UpdateProfileAsync(SystemAccount account);
    }

}
