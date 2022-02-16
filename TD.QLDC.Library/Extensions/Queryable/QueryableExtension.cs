using System;
using System.Linq;
using System.Linq.Expressions;

namespace TD.QLDC.Library.Extensions.Queryable
{
    public static class QueryableExtension
    {
        public static IQueryable<T> Filter<T>(this IQueryable<T> query, bool condition, Expression<Func<T, bool>> expression)
        {
            if (!condition) return query;

            var newQuery = query.Where(expression);
            return newQuery;
        }
    }
}
