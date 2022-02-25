using TD.QLDC.Library.ViewModels.Dashboard;

namespace TD.QLDC.Library.Services.Interfaces
{
    public interface IDashboardService
    {
        Widget GetWidget();
        Chart GetChart1();
        Chart GetChartHoGiaDinhTheoXom();
        Chart GetChart2();
        Chart GetChartNhanKhauTheoXom();
        Chart GetChart3();
        Chart GetChartDanToc();
        Chart GetChartTonGiao();
        Chart GetChartDoiTuong();
        Chart GetChartDoTuoi();
        Chart GetChartTrinhDoHocVan();
        Chart GetChartNganhNgheLaoDong();
        Chart GetChartGioiTinh();
        Chart GetChartTinhTrangHonNhan();
        Chart GetChartBaoHiemYTe();
        Chart GetChartLoaiDoiTuong();
    }
}
