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
        }

        public void DeleteAccount(int id)
        {
            Account finder = context.Accounts.FirstOrDefault(e => e.AccountId == id);
            if (finder != null)
            {
               context.Remove(finder);
            }
        }

        public void EditAccount(int id)
        {
            Account EditTarget = context.Accounts.FirstOrDefault(e => e.AccountId == id);

            
        }

        public List<Account> GetAccount()
        {
            return Accounts = context.Accounts.ToList();
        }
    }
}
