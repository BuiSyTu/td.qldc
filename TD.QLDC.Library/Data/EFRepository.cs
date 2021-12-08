using System;
using System.Data.Entity;
using System.Linq;
using TD.Core.Api;
using TD.Core.Api.Mvc;
using TD.Core.Api.Mvc.Extensions;
using TD.QLDC.Library.Interfaces;
using TD.QLDC.Library.Models;

namespace TD.QLGD.Library
{
	public class EFRepository<T> : EFRepository<T, int>, IRepository<T>  where T : Entity<int>, new()
    {
        public EFRepository(QLDCDbContext context, ICoreContextAccessor ctxAccessor)
		: base(context, ctxAccessor)
        {
        }

        protected IQueryable<T> CreateSearchQuery(DbSet<T> query, string search)
        {
            var FreetextFields = EfSpecificationEvaluator<T>.GetFreeTextFields();
            if (!string.IsNullOrEmpty(search))
            {
                if (FreetextFields == null)
                {
                    throw new NotSupportedException("Thi modal type does not support text search");
                }

                var fieldList = string.Join(",", FreetextFields);
                if (fieldList.Length == 0)
                {
                    throw new NotSupportedException("Thi modal type does not support text search");
                }
                return query.FullTextSearch(fieldList, search, EfSpecificationEvaluator<T>.GetSearchAlgorithm());
            }
            return query.AsQueryable();
        }
    }
}