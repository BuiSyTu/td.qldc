using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using TD.Core.Api.Mvc;
using TD.QLDC.Library.Models;
using TD.QLDC.Library.Repositories.Interfaces;
using TD.QLGD.Library;

namespace TD.QLDC.Library.Repositories.Implementations
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        private QLDCDbContext _dbContext;
        
        public CategoryRepository(
            QLDCDbContext dbContext,
            ICoreContextAccessor contextAccessor
        ) : base(dbContext, contextAccessor)
        {
            _dbContext = dbContext;
        }

        public int Count(
           string search = null,
           int? nhomId = null,
           bool? active = null
        )
        {
            return _dbContext.Categories
                .FilterNhomId(nhomId)
                .FilterSearchValue(search)
                .FilterActive(active)
                .Count();
        }

        public ICollection<Category> Get(
            int skip = 0,
            int take = 100,
            string search = null,
            string orderBy = null,
            string includes = null,
            int? nhomId = null,
            bool? active = null
        )
        {
            return _dbContext.Categories
                .IncludeMany(includes)
                .FilterNhomId(nhomId)
                .FilterSearchValue(search)
                .FilterActive(active)
                .OrderByMany(orderBy)
                .Skip(skip)
                .Take(take)
                .ToList();
        }

        public Category GetByNameAndCreateIfNotExist(int nhomDanhMucId, string name)
        {
            var query =  _dbContext.Categories.Where(x => x.NhomID == nhomDanhMucId && x.Name == name);

            if (query.Count() > 0)
            {
                return query.First();
            }

            Category newCategory = new()
            {
                NhomID = nhomDanhMucId,
                Name = name
            };

            var entity = Add(newCategory);
            return entity;
        }
    }

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
