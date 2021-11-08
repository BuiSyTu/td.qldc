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

    public interface INhomDanhMucRepository : IRepository<NhomDanhMuc>
    {

        List<NhomDanhMuc> Get(
            int skip = 0, int take = 100,
            string search = null,
            ICollection<string> orderBy = null,
            ICollection<string> include = null);
            //int? nhomid = null
        NhomDanhMuc Get(NhomDanhMuc entity);
        int Count(
           string search = null,
           ICollection<string> orderBy = null,
           ICollection<string> include = null
       );
    }

    public class NhomDanhMucRepository : EFRepository<NhomDanhMuc>, INhomDanhMucRepository
    {
        private QLDCDbContext _dbContext;

        public NhomDanhMucRepository(
            QLDCDbContext dbContext,
            ICoreContextAccessor contextAccessor
        ) : base(dbContext, contextAccessor)
        {
            _dbContext = dbContext;
        }

        public NhomDanhMuc Get(NhomDanhMuc entity)
        {
            var item = _dbContext.NhomDanhMucs.FirstOrDefault(i => i.ID == entity.ID);
            return item;
        }
        private IQueryable<NhomDanhMuc> CreateQuery(
            string search,
            ICollection<string> orderBy,
            ICollection<string> include
            )
        {
            var query = _dbContext.NhomDanhMucs.AsQueryable();

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
                var ids = CreateSearchQuery(_dbContext.NhomDanhMucs, search).Select(x => x.ID).ToList();
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

        public List<NhomDanhMuc> Get(
            int skip = 0, int take = 100,
            string search = null,
            ICollection<string> orderBy = null,
            ICollection<string> include = null
            )
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

