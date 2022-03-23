using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using TD.Core.Api.Mvc;
using TD.QLDC.Library.Common;
using TD.QLDC.Library.Models;
using TD.QLDC.Library.Repositories.Interfaces;

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

        public override Category Add(Category model)
        {
            model.FullTextSearch = CommonService.GenerateFullTextSearch(new List<string>
            {
                model.Name,
                model.Nhom.Name,
            });
            return base.Add(model);
        }

        public override void Update(Category model)
        {
            model.FullTextSearch = CommonService.GenerateFullTextSearch(new List<string>
            {
                model.Name,
                model.Nhom.Name,
            });

            base.Update(model);
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

        public Category GetSingleByTags(string tags)
        {
            return _dbContext.Categories.FirstOrDefault(x => x.Tags.Contains(tags));
        }
    }
}
