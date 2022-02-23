using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using TD.Core.Api.Mvc;
using TD.QLDC.Library.Models;
using TD.QLDC.Library.Repositories.Interfaces;

namespace TD.QLDC.Library.Repositories.Implementations
{
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
                .Filter(
                    !string.IsNullOrEmpty(q),
                    x => x.Name.Contains(q)|| x.Code.Contains(q)
                )
                .Filter(
                    !string.IsNullOrEmpty(areaCode),
                    x => x.Code == areaCode
                        || x.Parent.Code == areaCode
                        || x.Parent.Parent.Code == areaCode
                        || x.Parent.Parent.Parent.Code == areaCode
                        || x.Parent.Parent.Parent.Parent.Code == areaCode
                )
                .Filter(
                    type != null,
                    x => x.Type == type.ToString()
                )
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
                .Filter(
                    !string.IsNullOrEmpty(q),
                    x => x.Name.Contains(q) || x.Code.Contains(q)
                )
                .Filter(
                    !string.IsNullOrEmpty(areaCode),
                    x => x.Code == areaCode
                        || x.Parent.Code == areaCode
                        || x.Parent.Parent.Code == areaCode
                        || x.Parent.Parent.Parent.Code == areaCode
                        || x.Parent.Parent.Parent.Parent.Code == areaCode
                )
                .Filter(
                    type != null,
                    x => x.Type == type.ToString()
                )
                .FilterParentCode(parentCode)
                .OrderByMany(orderBy)
                .Skip(skip)
                .Take(top)
                .ToList();
        }

        public ICollection<Area> GetMultipleByName(string name, string includes = null)
        {
            return _dbContext.Areas
                .IncludeMany(includes)
                .Where(x => x.Name == name)
                .ToList();
        }

        public Area GetSingleByCode(string code, string includes = null)
        {
            return _dbContext.Areas
                .IncludeMany(includes)
                .FirstOrDefault(x => x.Code == code);
        }

        public Area GetSingleByName(string name)
        {
            return _dbContext.Areas.FirstOrDefault(x => x.Name == name);
        }
    }

    public static class QueryableAreaExtension
    {
        public static IQueryable<Area> FilterParentCode(this IQueryable<Area> query, string parentCode = null)
        {
            if (string.IsNullOrEmpty(parentCode)) return query;

            var newQuery = query.Where(x => x.Parent.Code == parentCode);
            return newQuery;
        }
    }
}
