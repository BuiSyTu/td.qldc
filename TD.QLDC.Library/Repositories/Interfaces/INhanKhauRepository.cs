using System.Collections.Generic;
using TD.QLDC.Library.Models;
using TD.QLDC.Library.ViewModels.Dashboard;

namespace TD.QLDC.Library.Repositories.Interfaces
{
    public interface INhanKhauRepository : IGenericRepository<NhanKhau>
    {
        ICollection<NhanKhau> Get(
            int skip = 0,
            int take = 100,
            string search = null,
            string orderBy = null,
            string includes = null,
            string shk = null,
            int? hoKhauId = null
        );

        int Count(
           string search = null,
           string shk = null,
           int? hoKhauId = null
       );

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
