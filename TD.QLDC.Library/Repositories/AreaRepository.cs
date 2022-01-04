using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TD.Core.Api.Mvc;
using TD.QLDC.Library.Models;

namespace TD.QLDC.Library.Repositories
{
    public interface IAreaRepository : IGenericRepository<Area>
    {
        ICollection<Area> Get(
            int skip = 0,
            int top = 20,
            string q = null,
            string includes = null,
            string orderBy = null,
            string areaCode = null,
            int? type = null,
            string parentCode = null);

        int Count(
            string q = null,
            string areaCode = null,
            int? type = null,
            string parentCode = null
        );

        Area GetSingleByCode(string code);
    }

    public class AreaRepository : GenericRepository<Area>, IAreaRepository
    {
        private QLDCDbContext _dbContext;

        public AreaRepository(
            QLDCDbContext dbContext,
            ICoreContextAccessor contextAccessor
        ) : base(dbContext, contextAccessor)
        {
            _dbContext = dbContext;
        }

        public int Count(string q = null, string areaCode = null, int? type = null, string parentCode = null)
        {
            return _dbContext.Areas
                .FilterSearchValue(q)
                .FilterAreaCode(areaCode)
                .FilterType(type)
                .FilterParentCode(parentCode)
                .Count();
        }

        public ICollection<Area> Get(
            int skip = 0,
            int top = 20,
            string q = null,
            string includes = null,
            string orderBy = null,
            string areaCode = null,
            int? type = null,
            string parentCode = null
        )
        {
            return _dbContext.Areas
                .IncludeMany(includes)
                .FilterSearchValue(q)
                .FilterAreaCode(areaCode)
                .FilterType(type)
                .FilterParentCode(parentCode)
                .OrderByMany(orderBy)
                .Skip(skip)
                .Take(top)
                .ToList();
        }

        public Area GetSingleByCode(string code)
        {
            return _dbContext.Areas.FirstOrDefault(x => x.Code == code);
        }
    }

    public static class QueryableAreaExtension
    {
        public static IQueryable<Area> FilterSearchValue(this IQueryable<Area> query, string search = null)
        {
            if (!string.IsNullOrEmpty(search))
            {
                query = query.Where(x =>
                    x.Name.Contains(search)
                    || x.Code.Contains(search));
            }
            return query;
        }

        public static IQueryable<Area> FilterAreaCode(this IQueryable<Area> query, string areaCode = null)
        {
            if (!string.IsNullOrEmpty(areaCode))
            {
                query = query.Where(x =>
                    x.Code == areaCode
                    || x.Parent.Code == areaCode
                    || x.Parent.Parent.Code == areaCode
                    || x.Parent.Parent.Parent.Code == areaCode
                    || x.Parent.Parent.Parent.Parent.Code == areaCode);
            }
            return query;
        }

        public static IQueryable<Area> FilterType(this IQueryable<Area> query, int? type = null)
        {
            if (type == null) return query;

            var newQuery = query.Where(x => x.Type == type.ToString());
            return newQuery;
        }

        public static IQueryable<Area> FilterParentCode(this IQueryable<Area> query, string parentCode = null)
        {
            if (string.IsNullOrEmpty(parentCode)) return query;

            var newQuery = query.Where(x => x.Parent.Code == parentCode);
            return newQuery;
        }
    }
}
