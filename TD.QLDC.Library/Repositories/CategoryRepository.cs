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

    public interface ICategoryRepository : IRepository<Category>
    {
        List<Category> Get(
            int skip = 0, int take = 100,
            string search = null,
            ICollection<string> orderBy = null,
            ICollection<string> include = null,
            int? nhomId = null,
            bool? active = null);

        Category Get(Category entity);

        int Count(
           string search = null,
           ICollection<string> orderBy = null,
           ICollection<string> include = null,
           int? nhomId = null,
           bool? active = null
       );

        Category GetByNameAndCreateIfNotExist(int nhomDanhMucId, string name);
    }

    public class CategoryRepository : EFRepository<Category>, ICategoryRepository
    {
        private QLDCDbContext _dbContext;
        
        public CategoryRepository(
            QLDCDbContext dbContext,
            ICoreContextAccessor contextAccessor
        ) : base(dbContext, contextAccessor)
        {
            _dbContext = dbContext;
        }

        public Category Get(Category entity)
        {
            var item = _dbContext.Categories.FirstOrDefault(i => i.ID == entity.ID);
            return item;
        }
        
        private IQueryable<Category> CreateQuery(
            string search,
            ICollection<string> orderBy,
            ICollection<string> include,
            int? nhomId,
            bool? active
        )
        {
            var query = _dbContext.Categories.AsQueryable();

            // includes
            if (include != null && include.Count > 0)
            {
                foreach (var item in include)
                {
                    query = query.Include(item);
                }
            }

            // sort
            if (orderBy == null || orderBy.Count == 0)
            {
                orderBy = new string[] { "ID" };
            }

            query = query.OrderBySQL(orderBy);

            // filter by active
            if (active != null)
            {
                query = query.Where(r => r.Active == active);
            }

            // filter by active
            if (nhomId.HasValue)
            {
                query = query.Where(r => r.NhomID == nhomId);
            }

            // search
            if (!string.IsNullOrEmpty(search))
            {
                var ids = CreateSearchQuery(_dbContext.Categories, search).Select(x => x.ID).ToList();
                query = query.Where(x => ids.Contains(x.ID));
            }

            // return result
            return query;
        }

        public int Count(
           string search = null,
           ICollection<string> orderBy = null,
           ICollection<string> include = null,
           int? nhomId = null,
           bool? active = null
       )
        {
            return CreateQuery(
                search,
                orderBy,
                include,
                nhomId,
                active
                ).Count();
        }

        public List<Category> Get(
            int skip = 0, int take = 100,
            string search = null,
            ICollection<string> orderBy = null,
            ICollection<string> include = null,
            int? nhomId = null,
            bool? active = null)
        {
            // load data
            var query = CreateQuery(
                search,
                orderBy,
                include,
                nhomId,
                active
                );

            if (skip > 0)
                query = query.Skip(skip);
            if (take > 0)
                query = query.Take(take);

            return query.ToList();
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
}
