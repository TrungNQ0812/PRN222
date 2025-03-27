using TrungNQ_Project_PRN222.Models;

namespace TrungNQ_Project_PRN222.Repositories
{
    public interface IAccountRepository
    {
        public List<Account> GetAccount();
        public void AddAccount(Account acc);
        public void EditAccount(int id);
        public void DeleteAccount(int id);
    }
}
