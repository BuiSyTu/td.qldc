using TD.QLDC.Library.ViewModels.Dashboard;

namespace TD.QLDC.Library.Services.Interfaces
{
    public interface IDashboardService
    {
        Widget GetWidget();
        Chart GetChart1();
        Chart GetChart2();
        Chart GetChart3();
        Chart GetChartDanToc();
        Chart GetChartTonGiao();
        Chart GetChartDoiTuong();
    }
}
