using NguyenQuangTrung_MVC.Models;

namespace NguyenQuangTrung_MVC.Repository
{
    public interface ISystemAccountRepository
    {
        public SystemAccount GetSystemAccountByEmail(string email);
        public List<SystemAccount> GetAllSystemAccounts();
        public SystemAccount GetAccountById(int id);
        public short GetAccountCount();
        public void AddNewAcc(SystemAccount acc);
        public void UpdateAccount(SystemAccount acc);
        public void DeleteAccount(int id);
    }
}
