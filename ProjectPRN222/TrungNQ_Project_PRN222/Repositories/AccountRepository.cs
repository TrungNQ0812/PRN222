using Microsoft.EntityFrameworkCore;
using TrungNQ_Project_PRN222.DAL;
using TrungNQ_Project_PRN222.Models;

namespace TrungNQ_Project_PRN222.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly InternalDocumentManagementContext context;

        public AccountRepository(InternalDocumentManagementContext DBcontext)
        {
            context = DBcontext;
        }

        List<Account> Accounts = new List<Account>();




        public void AddAccount(Account acc)
        {
            context.Accounts.Add(acc);
            context.SaveChanges();
        }

        public void DeleteAccount(int id)
        {
            Account finder = context.Accounts.FirstOrDefault(e => e.AccountId == id);
            if (finder != null)
            {
                finder.AccountStatus = 0; // 1-Active 0-Inactive
                context.SaveChanges();
            }

        }

        public void UpdateAccount(Account acc)
        {
            context.Accounts.Update(acc);
            context.SaveChanges();
        }

        public Account GetAccountByEmail(string email)
        {
            var result = context.Accounts.FirstOrDefault(a => a.Email == email);
            if(result != null)
            {
                return result;
            }
            return null;
        }

        public Account GetAccountById(int? Id)
        {
            var account = context.Accounts.FirstOrDefault(c => c.AccountId == Id);
            if (account != null)
            {
                return account;
            }
            return null;
        }

        public int GetAccountCount()
        {
            return context.Accounts.Count();
        }

        public List<Account> GetAccounts()
        {
            return Accounts = context.Accounts.Where(c => c.AccountStatus == 1).ToList();
        }
    }
}
