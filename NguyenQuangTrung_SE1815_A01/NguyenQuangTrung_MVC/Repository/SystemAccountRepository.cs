using Microsoft.AspNetCore.Http.HttpResults;
using NguyenQuangTrung_MVC.DAL;
using NguyenQuangTrung_MVC.Models;

namespace NguyenQuangTrung_MVC.Repository
{
    public class SystemAccountRepository : ISystemAccountRepository
    {
        private readonly FuNewsManagementContext _context;

        public SystemAccountRepository(FuNewsManagementContext context)
        {
            this._context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void AddNewAcc(SystemAccount acc)
        {

            _context.SystemAccounts.Add(acc);
            _context.SaveChanges();
        }

        public void DeleteAccount(int id)
        {
            var check = _context.SystemAccounts.FirstOrDefault(c => c.AccountId == id);
            if (check != null)
            {
                check.AccountStatus = "Deactivate";
            }
            _context.SaveChanges();
        }

        public SystemAccount GetAccountById(int id)
        {
            return _context.SystemAccounts.FirstOrDefault(c => c.AccountId == id);
        }

        public short GetAccountCount()
        {
            return (short)_context.SystemAccounts.Count();
        }

        public List<SystemAccount> GetAllSystemAccounts()
        {
           return _context.SystemAccounts.ToList();
        }

        public SystemAccount GetSystemAccountByEmail(string email)
        {
            var result = _context.SystemAccounts.FirstOrDefault(a => a.AccountEmail.Equals(email));
            if (result == null)
            {
                return null;
            }
            return result;

        }

        public void UpdateAccount(SystemAccount acc)
        {
            _context.SystemAccounts.Update(acc);
            _context.SaveChanges();
        }
    }
}
