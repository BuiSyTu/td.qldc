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
        ICollection<NhomDanhMuc> Get(
            int skip = 0,
            int take = 100,
            string search = null,
            string orderBy = null,
            string includes = null);
        int Count(string search = null);
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


        public int Count(
           string search = null

        )
        {
            return _dbContext.NhomDanhMucs
                .FilterSearchValue(search)
                .Count();
        }

        public ICollection<NhomDanhMuc> Get(
            int skip = 0, int take = 100,
            string search = null,
            string orderBy = null,
            string includes = null
            )
        {
            return _dbContext.NhomDanhMucs
                .IncludeMany(includes)
                .FilterSearchValue(search)
                .OrderByMany(orderBy)
                .Skip(skip)
                .Take(take)
                .ToList();
        }
    }

    public static class QueryableNhomDanhMucExtension
    {
        public static IQueryable<NhomDanhMuc> FilterSearchValue(this IQueryable<NhomDanhMuc> query, string searchValue = null)
        {
            if (string.IsNullOrEmpty(searchValue)) return query;

            var newQuery = query.Where(x => x.Name.Contains(searchValue));
            return newQuery;
        }
    }
}

