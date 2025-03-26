
using NguyenQuangTrungRazorPages.Models;
using NguyenQuangTrungRazorPages.Repositories;

namespace NguyenQuangTrungRazorPages.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;

        public AccountService(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public async Task<SystemAccount?> AuthenticateAsync(string email, string password)
        {
            var user = await _accountRepository.GetAccountByEmailAsync(email);
            if (user == null || user.AccountPassword != password)
            {
                return null;
            }
            return user;
        }
        public async Task<List<SystemAccount>> GetAllAsync(string? search = null, bool sortByIdAsc = true)
        {
            return await _accountRepository.GetAllAsync(search, sortByIdAsc);
        }

        public async Task<SystemAccount?> GetByIdAsync(short id)
        {
            return await _accountRepository.GetByIdAsync(id);
        }

        public async Task AddAsync(SystemAccount account)
        {
            await _accountRepository.AddAsync(account);
        }

        public async Task UpdateAsync(SystemAccount account)
        {
            await _accountRepository.UpdateAsync(account);
        }

        public async Task DeleteAsync(short accountId)
        {
            await _accountRepository.DeleteAsync(accountId);
        }
        public async Task<SystemAccount?> GetProfileAsync(short accountId)
        {
            return await _accountRepository.GetByIdAsync(accountId);
        }

        public async Task UpdateProfileAsync(SystemAccount account)
        {
            await _accountRepository.UpdateAsync(account);
        }

    }
}
