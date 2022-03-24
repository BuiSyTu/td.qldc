using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TD.QLDC.Library.Models;

namespace TD.QLDC.Library.Repositories.Implementations
{
    public static class QueryableCategoryExtension
    {
        public static IQueryable<Category> FilterSearchValue(this IQueryable<Category> query, string searchValue = null)
        {
            if (string.IsNullOrEmpty(searchValue)) return query;

            var newQuery = query.Where(x =>
                x.Name.Contains(searchValue)
                || x.Nhom.Name.Contains(searchValue));
            return newQuery;
        }

        public static IQueryable<Category> FilterNhomId(this IQueryable<Category> query, int? nhomId = null)
        {
            if (nhomId is null) return query;

            var newQuery = query.Where(x => x.NhomID == nhomId);
            return newQuery;
        }

        public static IQueryable<Category> FilterActive(this IQueryable<Category> query, bool? active)
        {
            if (active is null) return query;

            var newQuery = query.Where(x => x.Active == active);
            return newQuery;
        }
    }
}
