using System.Collections.Generic;
using TD.QLDC.Library.Interfaces;
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

        int CountDoiTuong();
        int CountTonGiao();
        int CountDanToc();
    }
}
