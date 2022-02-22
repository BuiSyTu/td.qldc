using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using TD.Core.Api.Mvc;
using TD.QLDC.Library.Common;
using TD.QLDC.Library.Models;
using TD.QLDC.Library.Repositories.Interfaces;
using TD.QLDC.Library.ViewModels.Dashboard;

namespace TD.QLDC.Library.Repositories.Implementations
{
    public class NhanKhauRepository : GenericRepository<NhanKhau>, INhanKhauRepository
    {
        private QLDCDbContext _dbContext;

        public NhanKhauRepository(
            QLDCDbContext dbContext,
            ICoreContextAccessor contextAccessor
        ) : base(dbContext, contextAccessor)
        {
            _dbContext = dbContext;
        }

        public int Count(
            string search = null,
            string shk = null,
            int? hoKhauId = null
        )
        {
            return _dbContext.NhanKhaus
                .FilterSoHoKhau(shk)
                .FilterHoKhauId(hoKhauId)
                .FilterCurrentAreaCode()
                .FilterSearchValue(search)
                .Count();
        }

        public ICollection<NhanKhau> Get(
            int skip = 0,
            int take = 100,
            string search = null,
            string orderBy = null,
            string includes = null,
            string shk = null,
            int? hoKhauId = null
        )
        {
            return _dbContext.NhanKhaus
                .IncludeMany(includes)
                .FilterHoKhauId(hoKhauId)
                .FilterSoHoKhau(shk)
                .FilterCurrentAreaCode()
                .FilterSearchValue(search)
                .OrderByMany(orderBy)
                .Skip(skip)
                .Take(take)
                .ToList();
        }

        public ICollection<ChartItem> GroupByXom()
        {
            return _dbContext.NhanKhaus
                .FilterCurrentAreaCode()
                .GroupBy(x => x.HoKhau.TenXom)
                .Select(g => new ChartItem
                {
                    Text = g.Key,
                    Value = g.Count().ToString()
                })
                .ToList();
        }

        public int CountDoiTuong()
        {
            return _dbContext.NhanKhaus
                .FilterCurrentAreaCode()
                .GroupBy(x => x.DMDoiTuongID)
                .Count();
        }

        public int CountTonGiao()
        {
            return _dbContext.NhanKhaus
                .FilterCurrentAreaCode()
                .GroupBy(x => x.DMTonGiaoID)
                .Count();
        }

        public int CountDanToc()
        {
            return _dbContext.NhanKhaus
                .FilterCurrentAreaCode()
                .GroupBy(x => x.DMDanTocID)
                .Count();
        }

        public ICollection<ChartItem> GroupByDoiTuong()
        {
            return _dbContext.NhanKhaus
                .Include(x => x.DMDoiTuong)
                .FilterCurrentAreaCode()
                .GroupBy(x => x.DMDoiTuong.Name)
                .Select(g => new ChartItem
                {
                    Text = g.Key,
                    Value = g.Count().ToString()
                })
                .ToList();
        }

        public ICollection<ChartItem> GroupByTonGiao()
        {
            return _dbContext.NhanKhaus
                .Include(x => x.DMTonGiao)
                .FilterCurrentAreaCode()
                .GroupBy(x => x.DMTonGiao.Name)
                .Select(g => new ChartItem
                {
                    Text = g.Key,
                    Value = g.Count().ToString()
                })
                .ToList();
        }

        public ICollection<ChartItem> GroupByDanToc()
        {
            return _dbContext.NhanKhaus
                .Include(x => x.DMDanToc)
                .FilterCurrentAreaCode()
                .GroupBy(x => x.DMDanToc.Name)
                .Select(g => new ChartItem
                {
                    Text = g.Key,
                    Value = g.Count().ToString()
                })
                .ToList();
        }

        public bool CheckExist(string hoTen, string cCCD, string ngaySinh)
        {
            return _dbContext.NhanKhaus
                .Filter(
                    !string.IsNullOrEmpty(hoTen),
                    x => x.HoTen.ToUpper() == hoTen.ToUpper()
                ).Filter(
                    !string.IsNullOrEmpty(cCCD),
                    x => x.SoCCCD == cCCD
                ).Filter(
                    !string.IsNullOrEmpty(ngaySinh),
                    x => x.NgaySinh == ngaySinh
                ).Any();
        }
    }

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
    }
}

