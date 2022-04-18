using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using TD.Core.Api.Mvc;
using TD.QLDC.Library.Common;
using TD.QLDC.Library.FilterModels;
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
            model.FullTextSearch = CommonService.GenerateFullTextSearch(new List<string>
            {
                model.CCCDCHuHo,
                model.TenChuHo,
                model.SoHoKhau,
                model.TenTinhThanh,
                model.TenQuanHuyen,
                model.TenXaPhuong,
                model.TenThon,
                model.TenXom
            });
            SetDefaultArea(model);
            base.Update(model);
        }

        public override HoKhau Add(HoKhau model)
        {
            model.FullTextSearch = CommonService.GenerateFullTextSearch(new List<string>
            {
                model.CCCDCHuHo,
                model.TenChuHo,
                model.SoHoKhau,
                model.TenTinhThanh,
                model.TenQuanHuyen,
                model.TenXaPhuong,
                model.TenThon,
                model.TenXom
            });
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

        public int Count(HoKhauFilterModel filterModel)
        {
            if (filterModel is null) filterModel = new HoKhauFilterModel();

            var initQuery = _dbContext.HoKhaus.AsQueryable();
            return CreateQuery(initQuery, filterModel).Count();
        }

        public ICollection<HoKhau> Get(HoKhauFilterModel filterModel)
        {
            if (filterModel is null) filterModel = new HoKhauFilterModel();

            var initQuery = _dbContext.HoKhaus.IncludeMany(filterModel.Includes);
            return CreateQuery(initQuery, filterModel)
                .OrderByMany(filterModel.OrderBy)
                .Skip(filterModel.Skip)
                .Take(filterModel.Top)
                .ToList();
        }

        private IQueryable<HoKhau> CreateQuery(IQueryable<HoKhau> query, HoKhauFilterModel filterModel)
        {
            return _dbContext.HoKhaus
                .IncludeMany(filterModel.Includes)
                .FilterCurrentAreaCode()
                .FilterAreaCode(filterModel.AreaCode)
                .Filter(filterModel.DMLoaiHoID != null, x => x.DMLoaiHoID == filterModel.DMLoaiHoID.Value)
                .FilterSearchValue(filterModel.Q);
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
                .GroupBy(x => new { x.TenXom, x.MaXom })
                .OrderBy(x => x.Key.MaXom)
                .Select(g => new ChartItem
                {
                    Text = g.Key.TenXom,
                    Value = g.Count().ToString()
                })
                .ToList();
        }

        public HoKhau GetSingleByNhanKhauCccd(string nhanKhauCccd)
        {
            if (string.IsNullOrEmpty(nhanKhauCccd)) return null;

            var nhanKhau = _dbContext.NhanKhaus
                .Include(x => x.HoKhau)
                .FirstOrDefault(x => x.SoCCCD == nhanKhauCccd);

            if (nhanKhau is null) return null;

            var hoKhau = nhanKhau.HoKhau;
            var nhanKhausInHoKhau = _dbContext.NhanKhaus
                .Where(x => x.HoKhauID == hoKhau.ID)
                .ToList();

            foreach (var item in nhanKhausInHoKhau)
            {
                nhanKhau.HoKhau = null;
            }

            hoKhau.ExtensionData["NhanKhaus"] = nhanKhausInHoKhau;

            return hoKhau;
        }

        public int CountLoaiHo()
        {
            return _dbContext.HoKhaus
                .FilterCurrentAreaCode()
                .GroupBy(x => x.DMLoaiHoID)
                .Count();
        }
    }
}
