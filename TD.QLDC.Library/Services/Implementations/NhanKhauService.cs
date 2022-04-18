using TD.QLDC.Library.Common;
using TD.QLDC.Library.FilterModels;
using TD.QLDC.Library.Models;
using TD.QLDC.Library.Repositories.Interfaces;
using TD.QLDC.Library.Services.Interfaces;

namespace TD.QLDC.Library.Services.Implementations
{
    public class NhanKhauService : INhanKhauService
    {
        private readonly INhanKhauRepository _repository;
        private readonly IAreaRepository _areaRepository;

        public NhanKhauService(INhanKhauRepository repository, IAreaRepository areaRepository)
        {
            _repository = repository;
            _areaRepository = areaRepository;
        }

        public NhanKhau GetByCccd(string cccd, string includes)
        {
            var nhanKhau = _repository.GetByCccd(cccd, includes);

            nhanKhau.ExtensionData["TenTinhThanhTamTru"] = !string.IsNullOrEmpty(nhanKhau.MaTinhThanhTamTru)
                ? _areaRepository.GetSingleByCode(nhanKhau.MaTinhThanhTamTru).Name
                : string.Empty;

            nhanKhau.ExtensionData["TenQuanHuyenTamTru"] = !string.IsNullOrEmpty(nhanKhau.MaQuanHuyenTamTru)
                ? _areaRepository.GetSingleByCode(nhanKhau.MaQuanHuyenTamTru).Name
                : string.Empty;

            nhanKhau.ExtensionData["TenXaPhuongTamTru"] = !string.IsNullOrEmpty(nhanKhau.MaXaPhuongTamTru)
                ? _areaRepository.GetSingleByCode(nhanKhau.MaXaPhuongTamTru).Name
                : string.Empty;

            return nhanKhau;
        }

        public Area GetCurrentTree(NhanKhauFilterModel filterModel)
        {
            string areaCode = filterModel.AreaCode;

            if (string.IsNullOrEmpty(areaCode))
            {
                areaCode = CommonService.GetCurrentAreaCode();
            }

            var area = _areaRepository.GetByCode(areaCode, includes: "Children");

            SetCount(area, filterModel);
            
            return area;
        }

        private void SetCount(Area area, NhanKhauFilterModel filterModel)
        {
            filterModel.AreaCode = area.Code;

            area.ExtensionData["Count"] = _repository.Count(filterModel);

            if (area.Children is null) return;

            foreach (var item in area.Children)
            {
                SetCount(item, filterModel);
            }
        }
    }
}
