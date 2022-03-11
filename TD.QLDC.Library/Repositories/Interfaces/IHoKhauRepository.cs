using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TD.QLDC.Library.Models;
using TD.QLDC.Library.ViewModels.Dashboard;

namespace TD.QLDC.Library.Repositories.Interfaces
{
    public interface IHoKhauRepository : IGenericRepository<HoKhau>
    {
        ICollection<HoKhau> Get(
            int skip = 0,
            int take = 100,
            string search = null,
            string orderBy = null,
            string includes = null);

        int Count(string search = null);

        int CheckMa(string shk);


        HoKhau GetBySoHoKhauAndCreateIfNotExist(string soHoKhau, int? loaiHoGiaDinhId = null);

        ICollection<ChartItem> GroupByXom();
        HoKhau GetSingleByNhanKhauCccd(string nhanKhauCccd);
    }
}
