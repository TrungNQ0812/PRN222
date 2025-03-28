using TrungNQ_Project_PRN222.Models;

namespace TrungNQ_Project_PRN222.Repositories
{
    public interface IAccountRepository
    {
        public List<Account> GetAccounts();
        public void AddAccount(Account acc);
        public void UpdateAccount(Account acc);
        public void DeleteAccount(int id);
        public int GetAccountCount();
        public Account GetAccountByEmail(string email);
    }
}
