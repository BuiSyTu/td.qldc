using System;
using System.Collections.Generic;
using TD.QLDC.Library.Repositories;
using TD.QLDC.Library.Repositories.Interfaces;
using TD.QLDC.Library.Services.Interfaces;
using TD.QLDC.Library.ViewModels.Dashboard;

namespace TD.QLDC.Library.Services.Implementations
{
    public class DashboardService : IDashboardService
    {
        private readonly IHoKhauRepository _hoKhauRepository;
        private readonly INhanKhauRepository _nhanKhauRepository;
        private readonly ICategoryRepository _categoryRepository;

        public DashboardService(
            IHoKhauRepository hoKhauRepository,
            INhanKhauRepository nhanKhauRepository,
            ICategoryRepository categoryRepository
        )
        {
            _hoKhauRepository = hoKhauRepository;
            _nhanKhauRepository = nhanKhauRepository;
            _categoryRepository = categoryRepository;
        }

        public Chart GetChart1()
        {
            return new Chart
            {
                Title = "Số lượng hộ gia đình theo xóm",
                Data = _hoKhauRepository.GroupByXom()
            };
        }

        public Chart GetChart2()
        {
            return new Chart
            {
                Title = "Số lượng nhân khẩu theo xóm",
                Data = _nhanKhauRepository.GroupByXom()
            };
        }

        public Chart GetChart3()
        {
            throw new NotImplementedException();
        }

        public Chart GetChartDanToc()
        {
            throw new NotImplementedException();
        }

        public Chart GetChartDoiTuong()
        {
            throw new NotImplementedException();
        }

        public Chart GetChartTonGiao()
        {
            throw new NotImplementedException();
        }

        public Widget GetWidget()
        {
            return new Widget
            {
                Title = "Thông tin widget",
                Data = new List<WidgetItem>
                {
                    new WidgetItem
                    {
                        Text = "Hộ gia đình",
                        Value = _hoKhauRepository.Count(),
                        BackgroundColor = WidgetColor.Info,
                        IconClass = "flaticon-imac"
                    },
                    new WidgetItem
                    {
                        Text = "Nhân khẩu",
                        Value = _nhanKhauRepository.Count(),
                        BackgroundColor = WidgetColor.Success,
                        IconClass = "flaticon-warning-2"
                    },
                    new WidgetItem
                    {
                        Text = "Dân tộc",
                        Value = _nhanKhauRepository.CountDanToc(),
                        BackgroundColor = WidgetColor.Warning,
                        IconClass = "flaticon-twitter-logo"
                    },
                    new WidgetItem
                    {
                        Text = "Tôn giáo",
                        Value = _nhanKhauRepository.CountTonGiao(),
                        BackgroundColor = WidgetColor.Danger,
                        IconClass = "flaticon-gift"
                    }
                }
            };
        }
    }
}
