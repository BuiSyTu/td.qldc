using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TD.QLDC.Library.Common;
using TD.QLDC.Library.Models;
using TD.QLDC.Library.Repositories.Interfaces;
using TD.QLDC.Library.Services.Interfaces;

namespace TD.QLDC.Library.Services.Implementations
{
    public class HoKhauService : IHoKhauService
    {
        private readonly IHoKhauRepository _repository;
        private readonly IAreaRepository _areaRepository;

        public HoKhauService(IHoKhauRepository repository, IAreaRepository areaRepository)
        {
            _repository = repository;
            _areaRepository = areaRepository;
        }

        public Area GetCurrentTree(string areaCode = null)
        {
            if (string.IsNullOrEmpty(areaCode))
            {
                areaCode = CommonService.GetCurrentAreaCode();
            }

            var area = _areaRepository.GetByCode(areaCode, includes: "Children");

            SetCount(area);

            return area;
        }

        private void SetCount(Area area)
        {
            area.ExtensionData["Count"] = _repository.Count(new FilterModels.HoKhauFilterModel
            {
                AreaCode = area.Code
            });

            if (area.Children is null) return;

            foreach (var item in area.Children)
            {
                SetCount(item);
            }
        }
    }
}
