using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TD.QLDC.Library.Common;
using TD.QLDC.Library.Models;
using TD.QLDC.Library.Repositories.Interfaces;

namespace TD.QLDC.Library.Repositories.Implementations
{
    public class AccountRepository : IAccountRepository
    {
        private readonly QLDCDbContext _context;

        public AccountRepository(QLDCDbContext context)
        {
            _context = context;
        }

        public Account ForgetPassword(string username)
        {
            throw new NotImplementedException();
        }

        public Account Get(string username, string password)
        {
            var md5Password = CommonService.CreateMD5(password);
            return _context.Accounts.FirstOrDefault(x => x.Username == username && x.MD5Password == md5Password);
        }

        public bool Login(string username, string password)
        {
            var md5Password = CommonService.CreateMD5(password);
            return _context.Accounts.Any(x => x.Username == username && x.MD5Password == md5Password);
        }

        public Account Register(string name, string username, string password)
        {
            var checkExist = _context.NhanKhaus.Any(x => x.SoCCCD == username);

            if (!checkExist) throw new Exception("Không thể đăng ký tài khoản này");

            var account = new Account
            {
                Name = name,
                Username = username,
                MD5Password = CommonService.CreateMD5(password)
            };

            var entity = _context.Accounts.Add(account);
             _context.SaveChanges();
            return entity;
        }
    }
}
