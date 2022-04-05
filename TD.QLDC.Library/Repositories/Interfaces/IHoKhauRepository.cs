using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TD.QLDC.Library.FilterModels;
using TD.QLDC.Library.Models;
using TD.QLDC.Library.ViewModels.Dashboard;

namespace TD.QLDC.Library.Repositories.Interfaces
{
    public interface IHoKhauRepository : IGenericRepository<HoKhau>
    {
        ICollection<HoKhau> Get(HoKhauFilterModel filterModel);

        int Count(HoKhauFilterModel filterModel);

        int CountLoaiHo();

        HoKhau GetBySoHoKhauAndCreateIfNotExist(string soHoKhau, int? loaiHoGiaDinhId = null);

        ICollection<ChartItem> GroupByXom();
        HoKhau GetSingleByNhanKhauCccd(string nhanKhauCccd);
    }
}
