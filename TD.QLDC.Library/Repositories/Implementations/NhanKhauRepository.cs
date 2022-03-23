using System;
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

        public override NhanKhau Add(NhanKhau model)
        {
            model.FullTextSearch = CommonService.GenerateFullTextSearch(new List<string>
            {
                model.DiaChiTamTru,
                model.Email,
                model.HoKhau.TenChuHo,
                model.HoKhau.CCCDCHuHo,
                model.HoTen,
                model.SoDienThoai,
                model.SoBHYT,
                model.SoCCCD,
                model.SoDienThoai,
                model.SoHC,
                model.TenGoiKhac,
            });

            return base.Add(model);
        }

        public override void Update(NhanKhau model)
        {
            model.FullTextSearch = CommonService.GenerateFullTextSearch(new List<string>
            {
                model.DiaChiTamTru,
                model.Email,
                model.HoKhau.TenChuHo,
                model.HoKhau.CCCDCHuHo,
                model.HoTen,
                model.SoDienThoai,
                model.SoBHYT,
                model.SoCCCD,
                model.SoDienThoai,
                model.SoHC,
                model.TenGoiKhac,
            });

            base.Update(model);
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
                .GroupBy(x => new { x.HoKhau.TenXom, x.HoKhau.MaXom })
                .OrderBy(x => x.Key.MaXom)
                .Select(g => new ChartItem
                {
                    Text = g.Key.TenXom,
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
                    Text = string.IsNullOrEmpty(g.Key) ? "Chưa rõ" : g.Key,
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
                    Text = string.IsNullOrEmpty(g.Key) ? "Chưa rõ" : g.Key,
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
                    Text = string.IsNullOrEmpty(g.Key) ? "Chưa rõ" : g.Key,
                    Value = g.Count().ToString()
                })
                .ToList();
        }

        public ICollection<ChartItem> GroupByTrinhDoHocVan()
        {
            return _dbContext.NhanKhaus
                .FilterCurrentAreaCode()
                .GroupBy(x => x.TrinhDoHocVan)
                .Select(g => new ChartItem
                {
                    Text = string.IsNullOrEmpty(g.Key) ? "Chưa rõ" : g.Key,
                    Value = g.Count().ToString()
                })
                .ToList();
        }

        public ICollection<ChartItem> GroupByNgheNghiep()
        {
            return _dbContext.NhanKhaus
                .FilterCurrentAreaCode()
                .GroupBy(x => x.NgheNghiep)
                .Select(g => new ChartItem
                {
                    Text = string.IsNullOrEmpty(g.Key) ? "Chưa rõ" : g.Key,
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

        public ICollection<ChartItem> GroupByGioiTinh()
        {
            return _dbContext.NhanKhaus
                .FilterCurrentAreaCode()
                .GroupBy(x => x.GioiTinh)
                .Select(g => new ChartItem
                {
                    Text = string.IsNullOrEmpty(g.Key) ? "Chưa rõ" : g.Key,
                    Value = g.Count().ToString()
                })
                .ToList();
        }

        public ICollection<ChartItem> GroupByNgaySinh()
        {
            var ngaySinhs = _dbContext.NhanKhaus
                .FilterCurrentAreaCode()
                .GroupBy(x => x.NgaySinh)
                .Select(g => new ChartItem
                {
                    Text = string.IsNullOrEmpty(g.Key) ? "Chưa rõ" : g.Key,
                    Value = g.Count().ToString()
                })
                .ToList();

            List<ChartItem> doTuois = new()
            {
                new ChartItem
                {
                    Text = "Chưa rõ",
                    Value = "0"
                },
                new ChartItem
                {
                    Text = "Từ 0 - 2",
                    Value = "0"
                },
                new ChartItem
                {
                    Text = "Từ 2 - 5",
                    Value = "0"
                },
                new ChartItem
                {
                    Text = "Từ 6 - 10",
                    Value = "0"
                },
                new ChartItem
                {
                    Text = "Từ 11 - 14",
                    Value = "0"
                },
                new ChartItem
                {
                    Text = "Từ 15 - 17",
                    Value = "0"
                },
                new ChartItem
                {
                    Text = "Từ 18 - 22",
                    Value = "0"
                },
                new ChartItem
                {
                    Text = "Từ 23 - 30",
                    Value = "0"
                },
                new ChartItem
                {
                    Text = "Từ 30 - 40",
                    Value = "0"
                },
                new ChartItem
                {
                    Text = "Từ 41 - 50",
                    Value = "0"
                },
                new ChartItem
                {
                    Text = "Từ 51 - 60",
                    Value = "0"
                },
                new ChartItem
                {
                    Text = "Từ 61 - 70",
                    Value = "0"
                }
            };

            foreach (var ngaySinh in ngaySinhs)
            {
                if (DateTime.TryParse(ngaySinh.Text, out DateTime ngaySinhCV))
                {
                    var tuoi = DateTime.Now.Year - ngaySinhCV.Year;

                    if (tuoi <= 2)
                    {
                        var doTuoi = doTuois.FirstOrDefault(x => x.Text == "Từ 0 - 2");
                        doTuoi.Value = (int.Parse(doTuoi.Value) + int.Parse(ngaySinh.Value)).ToString();
                    } 
                    else if (tuoi <= 5)
                    {
                        var doTuoi = doTuois.FirstOrDefault(x => x.Text == "Từ 2 - 5");
                        doTuoi.Value = (int.Parse(doTuoi.Value) + int.Parse(ngaySinh.Value)).ToString();
                    }
                    else if (tuoi <= 10)
                    {
                        var doTuoi = doTuois.FirstOrDefault(x => x.Text == "Từ 6 - 10");
                        doTuoi.Value = (int.Parse(doTuoi.Value) + int.Parse(ngaySinh.Value)).ToString();
                    }
                    else if (tuoi <= 14)
                    {
                        var doTuoi = doTuois.FirstOrDefault(x => x.Text == "Từ 11 - 14");
                        doTuoi.Value = (int.Parse(doTuoi.Value) + int.Parse(ngaySinh.Value)).ToString();
                    }
                    else if (tuoi <= 17)
                    {
                        var doTuoi = doTuois.FirstOrDefault(x => x.Text == "Từ 15 - 17");
                        doTuoi.Value = (int.Parse(doTuoi.Value) + int.Parse(ngaySinh.Value)).ToString();
                    }
                    else if (tuoi <= 22)
                    {
                        var doTuoi = doTuois.FirstOrDefault(x => x.Text == "Từ 18 - 22");
                        doTuoi.Value = (int.Parse(doTuoi.Value) + int.Parse(ngaySinh.Value)).ToString();
                    }
                    else if (tuoi <= 30)
                    {
                        var doTuoi = doTuois.FirstOrDefault(x => x.Text == "Từ 23 - 30");
                        doTuoi.Value = (int.Parse(doTuoi.Value) + int.Parse(ngaySinh.Value)).ToString();
                    }
                    else if (tuoi <= 40)
                    {
                        var doTuoi = doTuois.FirstOrDefault(x => x.Text == "Từ 31 - 40");
                        doTuoi.Value = (int.Parse(doTuoi.Value) + int.Parse(ngaySinh.Value)).ToString();
                    }
                    else if (tuoi <= 50)
                    {
                        var doTuoi = doTuois.FirstOrDefault(x => x.Text == "Từ 41 - 50");
                        doTuoi.Value = (int.Parse(doTuoi.Value) + int.Parse(ngaySinh.Value)).ToString();
                    }
                    else if (tuoi <= 60)
                    {
                        var doTuoi = doTuois.FirstOrDefault(x => x.Text == "Từ 51 - 60");
                        doTuoi.Value = (int.Parse(doTuoi.Value) + int.Parse(ngaySinh.Value)).ToString();
                    }
                    else if (tuoi <= 70)
                    {
                        var doTuoi = doTuois.FirstOrDefault(x => x.Text == "Từ 61 - 70");
                        doTuoi.Value = (int.Parse(doTuoi.Value) + int.Parse(ngaySinh.Value)).ToString();
                    }
                } else
                {
                    var doTuoi = doTuois.FirstOrDefault(x => x.Text == "Chưa rõ");
                    doTuoi.Value = (int.Parse(doTuoi.Value) + int.Parse(ngaySinh.Value)).ToString();
                }
            }

            return doTuois;
        }

        public NhanKhau GetByCccd(string cccd, string includes)
        {
            return _dbContext.NhanKhaus
                .IncludeMany(includes)
                .Where(x => x.SoCCCD == cccd)
                .FirstOrDefault();
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

