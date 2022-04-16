using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TD.QLDC.Library.Common;
using TD.QLDC.Library.Constant;
using TD.QLDC.Library.Models;

namespace TD.QLDC.Library.Repositories.Implementations
{
    public static class QueryableNhanKhauExtension
    {
        public static IQueryable<NhanKhau> FilterSearchValue(this IQueryable<NhanKhau> query, string searchValue = null)
        {
            if (string.IsNullOrEmpty(searchValue)) return query;

            var newQuery = query.Where(x =>
                    x.HoTen.Contains(searchValue)
                    || x.SoCCCD.Contains(searchValue)
                    || x.NgheNghiep.Contains(searchValue)
                    || x.SoBHYT.Contains(searchValue));

            return newQuery;
        }

        public static IQueryable<NhanKhau> FilterHoKhauId(this IQueryable<NhanKhau> query, int? hoKhauId = null)
        {
            if (hoKhauId is null) return query;

            var newQuery = query.Where(x => x.HoKhauID == hoKhauId);
            return newQuery;
        }

        public static IQueryable<NhanKhau> FilterTrongDoTuoiNhapNgu(this IQueryable<NhanKhau> query, bool? trongDoTuoiNhapNgu = null)
        {
            if (trongDoTuoiNhapNgu is null || !trongDoTuoiNhapNgu.Value) return query;

            var curYear = DateTime.Now.Year;
            var newQuery = query.Where(x => x.NgaySinh.HasValue && (curYear - x.NgaySinh.Value.Year) >= 18 && (curYear - x.NgaySinh.Value.Year <= 27));
            return newQuery;
        }

        public static IQueryable<NhanKhau> FilterSoHoKhau(this IQueryable<NhanKhau> query, string soHoKhau = null)
        {
            if (string.IsNullOrEmpty(soHoKhau)) return query;

            var newQuery = query.Where(x => x.HoKhau.SoHoKhau == soHoKhau);

            return newQuery;
        }

        public static IQueryable<NhanKhau> FilterCurrentAreaCode(this IQueryable<NhanKhau> query)
        {
            var areaCode = CommonService.GetCurrentAreaCode();
            if (string.IsNullOrEmpty(areaCode)) return query;

            var newQuery = query.Where(x =>
                x.HoKhau.MaTinhThanh == areaCode
                || x.HoKhau.MaQuanHuyen == areaCode
                || x.HoKhau.MaXaPhuong == areaCode
                || x.HoKhau.MaThon == areaCode
                || x.HoKhau.MaXom == areaCode);
            return newQuery;
        }

        public static IQueryable<NhanKhau> FilterBHYTStatus(this IQueryable<NhanKhau> query, int? bhytStatus)
        {
            if (bhytStatus is null) return query;

            if (bhytStatus == BHYTStatus.DuocMien)
            {
                var newQuery = query.Where(x => x.DuocMienBHYT.HasValue && x.DuocMienBHYT.Value);
                return newQuery;
            }

            if (bhytStatus == BHYTStatus.SapDenHan)
            {
                var tmpCheckDate = DateTime.Now.AddMonths(1);

                var newQuery = query.Where(x =>
                    x.HanSuDungBHYT.HasValue
                    && x.HanSuDungBHYT.Value >= DateTime.Now
                    && x.HanSuDungBHYT.Value <= tmpCheckDate
                );

                return newQuery;
            }

            if (bhytStatus == BHYTStatus.QuaHan)
            {
                var newQuery = query.Where(x =>
                    x.HanSuDungBHYT.HasValue
                    && x.HanSuDungBHYT.Value <= DateTime.Now
                );

                return newQuery;
            }

            return query;
        }

        public static IQueryable<NhanKhau> FilterTuTuoi(this IQueryable<NhanKhau> query, int? tuTuoi = null)
        {
            if (tuTuoi is null) return query;

            var curYear = DateTime.Now.Year;
            var newQuery = query.Where(x => x.NgaySinh.HasValue && (curYear - x.NgaySinh.Value.Year) >= tuTuoi.Value);
            return newQuery;
        }

        public static IQueryable<NhanKhau> FilterDenTuoi(this IQueryable<NhanKhau> query, int? denTuoi = null)
        {
            if (denTuoi is null) return query;

            var curYear = DateTime.Now.Year;
            var newQuery = query.Where(x => x.NgaySinh.HasValue && (curYear - x.NgaySinh.Value.Year) <= denTuoi.Value);
            return newQuery;
        }

        public static IQueryable<NhanKhau> FilterAreaCode(this IQueryable<NhanKhau> query, string areaCode = null)
        {
            if (string.IsNullOrEmpty(areaCode)) return query;

            var newQuery = query.Where(x =>
                x.HoKhau.MaTinhThanh == areaCode
                || x.HoKhau.MaQuanHuyen == areaCode
                || x.HoKhau.MaXaPhuong == areaCode
                || x.HoKhau.MaThon == areaCode
                || x.HoKhau.MaXom == areaCode);
            return newQuery;
        }
    }
}
