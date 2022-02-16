using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using TD.Core.Api.Mvc;
using TD.QLDC.Library.Common;
using TD.QLDC.Library.Models;
using TD.QLDC.Library.Repositories.Interfaces;
using TD.QLDC.Library.ViewModels.Dashboard;

namespace TD.QLDC.Library.Repositories.Implementations
{
    public class HoKhauRepository : GenericRepository<HoKhau>, IHoKhauRepository
    {
        private readonly QLDCDbContext _dbContext;

        public HoKhauRepository(
            QLDCDbContext dbContext,
            ICoreContextAccessor contextAccessor
        ) : base(dbContext, contextAccessor)
        {
            _dbContext = dbContext;
        }

        public override void Update(HoKhau model)
        {
            SetDefaultArea(model);
            base.Update(model);
        }

        public override HoKhau Add(HoKhau model)
        {
            SetDefaultArea(model);
            return base.Add(model);
        }

        private void SetDefaultArea(HoKhau model)
        {
            if (string.IsNullOrEmpty(model.MaTinhThanh))
            {
                model.MaTinhThanh = ConfigurationManager.AppSettings["ProvinceCode"] ?? "";
            }

            if (string.IsNullOrEmpty(model.TenTinhThanh))
            {
                model.TenTinhThanh = ConfigurationManager.AppSettings["ProvinceName"] ?? "";
            }

            if (string.IsNullOrEmpty(model.MaQuanHuyen))
            {
                model.MaQuanHuyen = ConfigurationManager.AppSettings["DistrictCode"] ?? "";
            }

            if (string.IsNullOrEmpty(model.TenQuanHuyen))
            {
                model.TenQuanHuyen = ConfigurationManager.AppSettings["DistrictName"] ?? "";
            }

            if (string.IsNullOrEmpty(model.MaXaPhuong))
            {
                model.MaXaPhuong = ConfigurationManager.AppSettings["WardCode"] ?? "";
            }

            if (string.IsNullOrEmpty(model.TenXaPhuong))
            {
                model.TenXaPhuong = ConfigurationManager.AppSettings["WardName"] ?? "";
            }
        }

        public int Count(
           string search = null
        )
        {
            return _dbContext.HoKhaus
                .FilterCurrentAreaCode()
                .FilterSearchValue(search)
                .Count();
        }

        public int CheckMa(string shk)
        {
            if (string.IsNullOrEmpty(shk)) return 0;

            var data = _dbContext.HoKhaus.FirstOrDefault(HoKhau => HoKhau.SoHoKhau == shk);
            return data == null ? 0 : 1;
        }

        public ICollection<HoKhau> Get(
            int skip = 0,
            int take = 100,
            string search = null,
            string orderBy = null,
            string includes = null)
        {
            return _dbContext.HoKhaus
                .IncludeMany(includes)
                .FilterCurrentAreaCode()
                .FilterSearchValue(search)
                .OrderByMany(orderBy)
                .Skip(skip)
                .Take(take)
                .ToList();
        }

        public HoKhau GetBySoHoKhauAndCreateIfNotExist(string soHoKhau, int? loaiHoGiaDinhId = null)
        {
            var query = _dbContext.HoKhaus.Where(x => x.SoHoKhau == soHoKhau);

            if (query.Count() > 0)
            {
                return query.First();
            }

            HoKhau newHoKhau = new()
            {
                SoHoKhau = soHoKhau,
                DMLoaiHoID = loaiHoGiaDinhId
            };

            var entity = Add(newHoKhau);
            return entity;
        }

        public ICollection<ChartItem> GroupByXom()
        {
            return _dbContext.HoKhaus
                .FilterCurrentAreaCode()
                .GroupBy(x => x.TenXom)
                .Select(g => new ChartItem
                {
                    Text = g.Key,
                    Value = g.Count().ToString()
                })
                .ToList();
        }
    }

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
