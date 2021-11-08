using System;
using System.Data.Entity;
using System.Linq;
using TD.Core.Api;
using TD.Core.Api.Common;
using TD.Core.Api.Mvc;
using TD.Core.Api.Mvc.Extensions;
using TD.QLDC.Library.Interfaces;
using TD.QLDC.Library.Models;

namespace TD.QLGD.Library
{
	public class EFRepository<T> : EFRepository<T, int>, IRepository<T>  where T : Entity<int>, new()
    {
        private readonly QLDCDbContext dbcontext;
        private readonly ICoreContextAccessor _ctxAccessor;
        public EFRepository(QLDCDbContext context, ICoreContextAccessor ctxAccessor)
		: base(context, ctxAccessor)
        {
            dbcontext = context;
            _ctxAccessor = ctxAccessor;
        }

        protected IQueryable<T> CreateSearchQuery(IQueryable<T> query, string search)
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
                query = query.FullTextSearch(fieldList, search, EfSpecificationEvaluator<T>.GetSearchAlgorithm());
                return query;
            }
            return query;
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

        public virtual int Count(string search = null)
        {
            try
            {
                return CreateSearchQuery(dbcontext.Set<T>(), search).Count();
            }
            catch (Exception ex)
            {
                throw new ApiException("Error getting count", ex);
            }
        }
    }
}