using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TD.QLDC.Library.Common;
using TD.QLDC.Library.Models;

namespace TD.QLDC.Library.Repositories.Implementations
{
    public static class QueryableHoKhauExtension
    {
        public static IQueryable<HoKhau> FilterSearchValue(this IQueryable<HoKhau> query, string searchValue = null)
        {
            if (string.IsNullOrEmpty(searchValue)) return query;

            var newQuery = query.Where(x => x.SoHoKhau.Contains(searchValue)
                    || x.SoNha.Contains(searchValue)
                    || x.TenThon.Contains(searchValue)
                    || x.TenXom.Contains(searchValue)
                    || x.TenChuHo.Contains(searchValue));

            return newQuery;
        }

        public static IQueryable<HoKhau> FilterCurrentAreaCode(this IQueryable<HoKhau> query)
        {
            var areaCode = CommonService.GetCurrentAreaCode();

            if (string.IsNullOrEmpty(areaCode)) return query;

            var newQuery = query.Where(x =>
                x.MaTinhThanh == areaCode
                || x.MaQuanHuyen == areaCode
                || x.MaXaPhuong == areaCode
                || x.MaThon == areaCode
                || x.MaXom == areaCode);
            return newQuery;
        }
    }
}
