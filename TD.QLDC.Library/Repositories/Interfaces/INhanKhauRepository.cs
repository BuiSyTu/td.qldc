using System.Collections.Generic;
using TD.QLDC.Library.FilterModels;
using TD.QLDC.Library.Models;
using TD.QLDC.Library.ViewModels.Dashboard;

namespace TD.QLDC.Library.Repositories.Interfaces
{
    public interface INhanKhauRepository : IGenericRepository<NhanKhau>
    {
        ICollection<NhanKhau> Get(NhanKhauFilterModel filterModel);

        int Count(NhanKhauFilterModel filterModel);

        ICollection<ChartItem> GroupByXom();

        ICollection<ChartItem> GroupByDoiTuong();

        ICollection<ChartItem> GroupByTonGiao();

        ICollection<ChartItem> GroupByDanToc();

        ICollection<ChartItem> GroupByTrinhDoHocVan();

        ICollection<ChartItem> GroupByNgheNghiep();

        ICollection<ChartItem> GroupByGioiTinh();

        ICollection<ChartItem> GroupByNgaySinh();

        int CountDoiTuong();
        int CountTonGiao();
        int CountDanToc();

        bool CheckExist(string hoTen, string cCCD, string ngaySinh);

        NhanKhau GetByCccd(string cccd, string includes);
    }
}
