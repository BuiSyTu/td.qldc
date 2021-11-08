using System;
using TD.QLDC.Library.Models;
using TD.Core.Api.Common;
using TD.Core.Api.Mvc.Generic;
using System.Collections.Generic;
using TD.Core.Api.Mvc.Extensions;
using System.Data.Entity;
using Z.Expressions;
using System.Linq;
using TD.Core.Api.Mvc;
//using TD.Core.Utilities.AspNet;
//using TD.Core.UserPositions.Extensions;

namespace TD.QLDC.Library.Repositories
{
    public abstract class GenericRepository<T> : MvcApiControler<T, int>, IGenericController<T, int> where T : ModelBaseExt, new()
    {
        private TDCoreDbContext _dbContext;
        private ICoreContextAccessor _ctxAccessor;

        public GenericRepository(
            TDCoreDbContext dbContext,
            ICoreContextAccessor contextAccessor
        ) : base(dbContext)
        {
            _dbContext = dbContext;
            _ctxAccessor = contextAccessor;
        }

        public override FullTextIndex.SearchAlgorithm algorithm
        {
            get;
            set;
        } = FullTextIndex.SearchAlgorithm.Contains;

        public override List<T> Get(
            int skip = 0, int take = 100,
            string search = null, bool searchIsQuery = false,
            ICollection<string> orderBy = null, IEnumerable<string> viewFields = null)
        {
            if (orderBy == null || orderBy.Count == 0)
            {
                orderBy = new string[] { "ID" };
            }
            return base.Get(skip, take, search, false, orderBy, null);
        }

        public List<T> Get(
            int skip = 0, int take = 100,
            string search = null,
            ICollection<string> orderBy = null, ICollection<string> include = null, string field = null, object value = null)
        {
            if (orderBy == null || orderBy.Count == 0)
            {
                orderBy = new string[] { "ID" };
            }
            try
            {
                var query = CreateSearchQuery(_dbContext.Set<T>(), search, false);
                if (include != null)
                {
                    var ids = query.Select(x => x.ID).ToList();
                    query = _dbContext.Set<T>().AsQueryable();

                    foreach (var item in include)
                    {
                        query = query.Include(item);
                    }

                    query = query.Where(x => ids.Contains(x.ID));
                }
                if (!string.IsNullOrEmpty(field))
                {
                    query = query.Where(x => $"x.{field} == v", new { v = value });
                }
                query = query.OrderBySQL(orderBy);
                if (skip > 0)
                    query = query.Skip(skip);
                if (take > 0)
                    query = query.Take(take);
                return query.ToList();
            }
            catch (Exception ex)
            {
                throw new ApiException("Error getting items", ex);
            }
        }
        
        public override T Add(T entity)
        {
            entity.Created = DateTime.Now;
            //var userPosition = ContextItems.Current.UserPositionController
            //     .GetCurrentUserPosition();

            //if (userPosition != null)
            //    entity.CreatedBy = userPosition.Code;

            var uposCode = _ctxAccessor.UserPositionCode;
            entity.CreatedBy = uposCode;

            return base.Add(entity);
        }

        public override void Update(int id, T change)
        {
            var item = GetById(id);
            //var userPosition = ContextItems.Current.UserPositionController
            //      .GetCurrentUserPosition();

            if (item != null)
            {
                item.Modified = DateTime.Now;
                //if (userPosition != null)
                //    item.ModifiedBy = userPosition.Code;
                item.ModifiedBy = _ctxAccessor.UserPositionCode;
                base.Update(id, item);
            }
        }

        public virtual IEnumerable<T> AddRange(IEnumerable<T> entities)
        {
            //var userPosition = ContextItems.Current.UserPositionController
            //        .GetCurrentUserPosition();

            var uposCode = _ctxAccessor.UserPositionCode;

            foreach (var entity in entities)
            {
                entity.Created = DateTime.Now;
                //if (userPosition != null)
                //    entity.CreatedBy = userPosition.Code;

                entity.CreatedBy = uposCode;
            }
            var listTs = _dbContext.Set<T>().AddRange(entities);
            _dbContext.SaveChanges();
            return listTs;
        }

        public virtual IEnumerable<T> Export()
        {
            var listTs = _dbContext.Set<T>().ToList();
            return listTs;
        }

        public virtual IEnumerable<T> Import(IEnumerable<T> entities)
        {
            var listTs = _dbContext.Set<T>().AddRange(entities);
            _dbContext.SaveChanges();
            return listTs;
        }

        public virtual int CountQuery(string search = null, string field = null, object value = null)
        {
            try
            {
                var query = CreateSearchQuery(_dbContext.Set<T>(), search, false);
                if(!string.IsNullOrEmpty(field))
                {
                    query = query.Where(x => $"x.{field} == v", new { v = value });
                }
                return query.Count();
            }
            catch (Exception ex)
            {
                throw new ApiException("Error getting count", ex);
            }
        }
    }
}
