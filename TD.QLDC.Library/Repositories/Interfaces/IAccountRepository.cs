using TD.QLDC.Library.Models;

namespace TD.QLDC.Library.Repositories.Interfaces
{
    public interface IAccountRepository
    {
        Account Get(string username, string password);
        Account Register(string name, string username, string password);
        bool Login(string username, string password);
        Account ForgetPassword(string username);
    }
}
