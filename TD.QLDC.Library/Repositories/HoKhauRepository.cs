using Microsoft.SharePoint;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using TD.Core.Api.Mvc;
using TD.Core.Api.Mvc.Extensions;
using TD.QLDC.Library.Interfaces;
using TD.QLDC.Library.Models;
using TD.QLGD.Library;

namespace TD.QLDC.Library.Repositories
{

    public interface IHoKhauRepository : IRepository<HoKhau>
    {
        List<HoKhau> Get(
            int skip = 0, int take = 100,
            string search = null,
            ICollection<string> orderBy = null,
            ICollection<string> include = null);
        HoKhau Get(HoKhau entity);
        int Count(
           string search = null,
           ICollection<string> orderBy = null,
           ICollection<string> include = null
       );
        int CheckMa(string shk);
        string GetSHKByID(int id);
    }

    public class HoKhauRepository : EFRepository<HoKhau>, IHoKhauRepository
    {
        private QLDCDbContext _dbContext;

        public HoKhauRepository(
            QLDCDbContext dbContext,
            ICoreContextAccessor contextAccessor
        ) : base(dbContext, contextAccessor)
        {
            _dbContext = dbContext;
        }

        public HoKhau Get(HoKhau entity)
        {
            var item = _dbContext.HoKhaus.FirstOrDefault(i => i.ID == entity.ID);
            return item;
        }
        
        private IQueryable<HoKhau> CreateQuery(
            string search,
            ICollection<string> orderBy,
            ICollection<string> include
            )
        {
            var query = _dbContext.HoKhaus.AsQueryable();

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
                var ids = CreateSearchQuery(_dbContext.HoKhaus, search).Select(x => x.ID).ToList();
                query = query.Where(x => ids.Contains(x.ID));
            }        
            // return result
            return query;
        }

        public int Count(
           string search = null,
           ICollection<string> orderBy = null,
           ICollection<string> include = null
       )
        {
            return CreateQuery(
                search,
                orderBy,
                include
                ).Count();
        }

        public int CheckMa(string shk)
        {
            if (!string.IsNullOrEmpty(shk))
            {
                var data = _dbContext.HoKhaus.FirstOrDefault(HoKhau => HoKhau.SoHoKhau == shk);
                if (data == null) return 0;
                else return 1;
            }
             return 0;           
        }
        //public string GetSHKByID(int id)
        //{
        //    var query = from hk in _dbContext.HoKhaus.AsQueryable()
        //                where hk.ID == id
        //                select hk.SoHoKhau;
                        
        //    return query.FirstOrDefault();
        //}
        public string GetSHKByID(int id)
        {
            var query = _dbContext.HoKhaus.FirstOrDefault(HoKhau => HoKhau.ID == id);
            return query.SoHoKhau;
        }
        public List<HoKhau> Get(
            int skip = 0, int take = 100,
            string search = null,
            ICollection<string> orderBy = null,
            ICollection<string> include = null)
        {
            // load data
            var query = CreateQuery(
                search,
                orderBy,
                include
                );

            if (skip > 0)
                query = query.Skip(skip);
            if (take > 0)
                query = query.Take(take);

            return query.ToList();
        }
    }
}
