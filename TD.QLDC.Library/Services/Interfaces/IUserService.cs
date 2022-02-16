using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TD.QLDC.Library.ViewModels;

namespace TD.QLDC.Library.Services.Interfaces
{
    public interface IUserService
    {
        string CreateJWT(PayLoadJWT payload);
    }
}
