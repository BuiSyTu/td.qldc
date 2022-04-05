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
using System.Text.RegularExpressions;
using TD.Core.Api;
using System.Data.Entity.Infrastructure;

namespace TD.QLDC.Library.Repositories
{
    public abstract class GenericRepository<T> : IGenericRepository<T> where T : ModelBaseExt
    {
        private readonly DbContext _context;
        private readonly ICoreContextAccessor _ctxAccessor;

        public GenericRepository(DbContext context, ICoreContextAccessor ctxAccessor)
        {
            _context = context;
            _ctxAccessor = ctxAccessor;
        }

        public virtual T Add(T model)
        {
            if (model is ModelBaseExt trackable)
            {
                trackable.Created = DateTime.Now;
            }

            _context.Set<T>().Add(model);
            _context.SaveChanges();
            return model;
        }

        public int Count() => _context.Set<T>().Count();

        public virtual T GetById(int id) => _context.Set<T>().Find(id);

        public virtual void Update(T model)
        {
            try
            {
                T entity;

                // partial update
                if (model is IPartialUpdatableEntity)
                {
                    entity = GetById(model.ID);
                    var delta = (IPartialUpdatableEntity)model;
                    var entry = _context.Entry(entity);
                    var type = typeof(T);
                    var fields = delta.GetChangedFields();

                    foreach (var field in fields)
                    {
                        var member = entry.Member(field);
                        if (member == null) continue;

                        var prop = type.GetProperty(field);
                        member.CurrentValue = prop.GetValue(model);

                        if (member is DbPropertyEntry)
                        {
                            (member as DbPropertyEntry).IsModified = true;
                        }
                    }

                    model = (T)entity;
                }
                else
                {
                    entity = model;
                    _context.Entry(model).State = EntityState.Modified;
                }

                // track changes
                if (entity is IModificationTrackableEntity)
                {
                    var trackable = (IModificationTrackableEntity)entity;
                    trackable.Modified = DateTime.Now;
                    trackable.ModifiedBy = _ctxAccessor.UserPositionCode;
                }

                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new ApiException("Error updating item", ex);
            }
        }

        public virtual ICollection<T> GetAll() => _context.Set<T>().ToList();

        public virtual void Delete(T model)
        {
            _context.Set<T>().Remove(model);
            _context.SaveChanges();
        }

        public ICollection<T> Get(
            int skip = 0,
            int take = 100,
            string search = null,
            bool searchIsQuery = false,
            ICollection<string> orderBy = null,
            IEnumerable<string> viewFields = null)
        {
            try
            {
                var query = _context.Set<T>().OrderBySQL(orderBy);
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
    }

    public static class QueryableExtension
    {
        public static IQueryable<T> IncludeMany<T>(this IQueryable<T> queryable, string include)
        {
            ICollection<string> includeCollection = null;
            if (!string.IsNullOrEmpty(include))
            {
                includeCollection = new Regex(@"\s*,\s*").Split(include);
            }

            if (includeCollection != null && includeCollection.Count > 0)
            {
                foreach (var item in includeCollection)
                {
                    queryable = queryable.Include(item);
                }
            }
            return queryable;
        }

        public static IQueryable<T> OrderByMany<T>(this IQueryable<T> queryable, string orderBy)
        {
            if (string.IsNullOrEmpty(orderBy))
            {
                queryable = queryable.OrderByDynamic(x => "x.ID");
                return queryable;
            }

            var splitChars = new char[] { '|' };

            ICollection<string> orderByCollection = null;
            if (!string.IsNullOrEmpty(orderBy))
            {
                orderByCollection = new Regex(@"\s*,\s*").Split(orderBy);
            }

            var checkOrdered = false;
            foreach (string str in orderByCollection)
            {
                if (string.IsNullOrEmpty(str))
                {
                    continue;
                }

                var spl = str.Split(splitChars);

                var field = spl[0];
                var desc = spl.Length > 1 && spl[1].ToUpper() == "DESC";

                if (!checkOrdered)
                {
                    if (desc)
                    {
                        queryable = queryable.OrderByDescendingDynamic(x => $"x.{field}");
                    }
                    else
                    {
                        queryable = queryable.OrderByDynamic(x => $"x.{field}");
                    }
                    checkOrdered = true;
                }
                else
                {
                    if (desc)
                    {
                        queryable = ((IOrderedQueryable<T>)queryable).ThenByDescendingDynamic(x => $"x.{field}");
                    }
                    else
                    {
                        queryable = ((IOrderedQueryable<T>)queryable).ThenByDynamic(x => $"x.{field}");
                    }
                }

            }

            return queryable;
        }
    }
}
