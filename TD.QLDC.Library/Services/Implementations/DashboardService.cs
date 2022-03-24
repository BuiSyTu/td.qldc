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

        public Chart GetChartHoGiaDinhTheoXom()
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

        public Chart GetChartNhanKhauTheoXom()
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

        public Chart GetChartBaoHiemYTe()
        {
            throw new NotImplementedException();
        }

        public Chart GetChartDanToc()
        {
            return new Chart
            {
                Title = "Số lượng nhân khẩu theo dân tộc",
                Data = _nhanKhauRepository.GroupByDanToc()
            };
        }

        public Chart GetChartDoiTuong()
        {
            throw new NotImplementedException();
        }

        public Chart GetChartDoTuoi()
        {
            return new Chart
            {
                Data = _nhanKhauRepository.GroupByNgaySinh(),
                Title = "Số lượng nhân khẩu theo độ tuổi"
            };
        }

        public Chart GetChartGioiTinh()
        {
            return new Chart
            {
                Data = _nhanKhauRepository.GroupByGioiTinh(),
                Title = "Số lượng nhân khẩu theo giới tính"
            };
;        }

        public Chart GetChartLoaiDoiTuong()
        {
            return new Chart
            {
                Data = _nhanKhauRepository.GroupByDoiTuong(),
                Title = "Số lượng nhân khẩu theo loại đối tượng"
            };
        }

        public Chart GetChartNganhNgheLaoDong()
        {
            return new Chart
            {
                Data = _nhanKhauRepository.GroupByNgheNghiep(),
                Title = "Số lượng nhân khẩu theo ngành nghề lao động"
            };
        }

        public Chart GetChartTinhTrangHonNhan()
        {
            throw new NotImplementedException();
        }

        public Chart GetChartTonGiao()
        {
            return new Chart
            {
                Title = "Số lượng nhân khẩu theo tôn giáo",
                Data = _nhanKhauRepository.GroupByTonGiao()
            };
        }

        public Chart GetChartTrinhDoHocVan()
        {
            return new Chart
            {
                Data = _nhanKhauRepository.GroupByTrinhDoHocVan(),
                Title = "Số lượng nhân khẩu theo trình độ học vấn"
            };
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
                        Text = "Đối tượng chính sách",
                        Value = _nhanKhauRepository.CountDoiTuong(),
                        BackgroundColor = WidgetColor.Warning,
                        IconClass = "flaticon-twitter-logo"
                    },
                    new WidgetItem
                    {
                        Text = "Loại hộ gia đình",
                        Value = _hoKhauRepository.CountLoaiHo(),
                        BackgroundColor = WidgetColor.Danger,
                        IconClass = "flaticon-gift"
                    }
                }
            };
        }
    }
}
