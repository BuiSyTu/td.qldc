using Microsoft.SharePoint;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using TD.Core.Api.Mvc;
using TD.Core.Api.Mvc.Extensions;
using TD.QLDC.Library.Interfaces;
using TD.QLDC.Library.Models;
using TD.QLGD.Library;

namespace TD.QLDC.Library.Repositories
{

    public interface INhanKhauRepository : IRepository<NhanKhau>
    {

        List<NhanKhau> Get(
            int skip = 0, int take = 100,
            string search = null,
            ICollection<string> orderBy = null,
            ICollection<string> include = null,
            string shk = null
            );

        List<NhanKhau> GetBySoHoKhau(string SoHoKhau);
        List<NhanKhau> UpdateTheoSHK(string shkc, string shk);

        NhanKhau Get(NhanKhau entity);
     
        int Count(
           string search = null,
           ICollection<string> orderBy = null,
           ICollection<string> include = null,
           string shk = null
       );
    }

    public class NhanKhauRepository : EFRepository<NhanKhau>, INhanKhauRepository
    {
        private QLDCDbContext _dbContext;

        public NhanKhauRepository(
            QLDCDbContext dbContext,
            ICoreContextAccessor contextAccessor
        ) : base(dbContext, contextAccessor)
        {
            _dbContext = dbContext;
        }

        public NhanKhau Get(NhanKhau entity)
        {
            var item = _dbContext.NhanKhaus.FirstOrDefault(i => i.ID == entity.ID);
            return item;
        }
        private IQueryable<NhanKhau> CreateQuery(
            string search,
            ICollection<string> orderBy,
            ICollection<string> include,
             string shk = null


            )
        {
            var query = _dbContext.NhanKhaus.AsQueryable();
           
            // includes
            if (include != null && include.Count > 0)
            {
                foreach (var item in include)
                {
                    query = query.Include(item);
                }
            }

            // sort
            if (orderBy == null || orderBy.Count == 0)
            {
                orderBy = new string[] { "ID" };
            }

            query = query.OrderBySQL(orderBy);

            // search
            if (!string.IsNullOrEmpty(search))
            {
                var ids = CreateSearchQuery(_dbContext.NhanKhaus, search).Select(x => x.ID).ToList();
                query = query.Where(x => ids.Contains(x.ID));
            }


            if (!string.IsNullOrEmpty(shk))
            {
                query = query.Where(x => x.SoHoKhau == shk);
            }
            
            // return result
            return query;
        }

        public int Count(
           string search = null,
           ICollection<string> orderBy = null,
           ICollection<string> include = null,
            string shk = null
       )
        {
            return CreateQuery(
                search,
                orderBy,
                include, 
                shk
                ).Count();
        }

        public List<NhanKhau> GetBySoHoKhau(string SoHoKhau)
        {
            //var quey = from p in _dbContext.NhanKhaus where p.SoHoKhau == SoHoKhau || LoaiLuuTru == "0" select p;
            var nhankhaus = _dbContext.NhanKhaus.Where(NhanKhau => NhanKhau.SoHoKhau == SoHoKhau).ToList();
            return nhankhaus;
            //return quey.ToList();
        }
        public List<NhanKhau> UpdateTheoSHK(string shkc, string shk)
        {
            //if (shkc != shk)
            //{
                var query = from nk in _dbContext.NhanKhaus.AsQueryable()
                            where nk.SoHoKhau == shkc
                            select nk;
                return query.ToList();
                var listnk = query.ToList();
                if (listnk != null)
                {
                    foreach (var item in listnk)
                    {
                        item.SoHoKhau = shk;
                    }
                }
                _dbContext.SaveChanges();                    
        }
        public List<NhanKhau> Get(
            int skip = 0, int take = 100,
            string search = null,
            ICollection<string> orderBy = null,
            ICollection<string> include = null,
             string shk = null
            )
        {
            // load data
            var query = CreateQuery(
                search,
                orderBy,
                include,
                shk
               

                );

            if (skip > 0)
                query = query.Skip(skip);
            if (take > 0)
                query = query.Take(take);

            return query.ToList();
        }

    }
}

