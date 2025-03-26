using Microsoft.EntityFrameworkCore;
using NguyenQuangTrungRazorPages.DAL;
using NguyenQuangTrungRazorPages.Models;
using System;

namespace NguyenQuangTrungRazorPages.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly FuNewsManagementContext _context;

        public AccountRepository(FuNewsManagementContext context)
        {
            _context = context;
        }

        public async Task<SystemAccount?> GetAccountByEmailAsync(string email)
        {
            return await _context.SystemAccounts
                .FirstOrDefaultAsync(a => a.AccountEmail == email);
        }
        public async Task<List<SystemAccount>> GetAllAsync(string? search = null, bool sortByIdAsc = true)
        {
            var query = _context.SystemAccounts.AsQueryable();

            if (!string.IsNullOrWhiteSpace(search))
            {
                query = query.Where(a => a.AccountName.Contains(search) || a.AccountEmail.Contains(search));
            }

            query = sortByIdAsc ? query.OrderBy(a => a.AccountId) : query.OrderByDescending(a => a.AccountId);

            return await query.ToListAsync();
        }

        public async Task<SystemAccount?> GetByIdAsync(short id)
        {
            return await _context.SystemAccounts.FindAsync(id);
        }

        public async Task AddAsync(SystemAccount account)
        {
            // Nếu AccountId không phải là IDENTITY, tự động tạo ID mới
            if (account.AccountId == 0) // hoặc kiểm tra null tùy vào kiểu dữ liệu
            {
                short maxId = await _context.SystemAccounts.MaxAsync(a => (short?)a.AccountId) ?? 0;
                account.AccountId = (short)(maxId + 1);
            }

            _context.SystemAccounts.Add(account);
            await _context.SaveChangesAsync();
        }


        public async Task UpdateAsync(SystemAccount account)
        {
            _context.SystemAccounts.Update(account);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(short accountId)
        {
            var account = await _context.SystemAccounts.FirstOrDefaultAsync(a => a.AccountId == accountId);
            if (account != null)
            {
                _context.SystemAccounts.Remove(account);
                await _context.SaveChangesAsync();
            }
        }
     



    }

}
