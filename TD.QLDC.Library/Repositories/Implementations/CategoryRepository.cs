using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using TD.Core.Api.Mvc;
using TD.QLDC.Library.Common;
using TD.QLDC.Library.FilterModels;
using TD.QLDC.Library.Models;
using TD.QLDC.Library.Repositories.Interfaces;

namespace TD.QLDC.Library.Repositories.Implementations
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        private readonly QLDCDbContext _dbContext;
        
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
                model?.Nhom?.Name ?? string.Empty,
                model.Tags
            });
            return base.Add(model);
        }

        public override void Update(Category model)
        {
            model.FullTextSearch = CommonService.GenerateFullTextSearch(new List<string>
            {
                model.Name,
                model?.Nhom?.Name ?? string.Empty,
            });

            base.Update(model);
        }

        public int Count(CategoryFilterModel filterModel)
        {
            return _dbContext.Categories
                .FilterNhomId(filterModel.NhomID)
                .FilterSearchValue(filterModel.Q)
                .FilterActive(filterModel.Active)
                .Count();
        }

        public ICollection<Category> Get(CategoryFilterModel filterModel)
        {
            return _dbContext.Categories
                .IncludeMany(filterModel.Includes)
                .FilterNhomId(filterModel.NhomID)
                .FilterSearchValue(filterModel.Q)
                .FilterActive(filterModel.Active)
                .OrderByMany(filterModel.OrderBy)
                .Skip(filterModel.Skip)
                .Take(filterModel.Top)
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

        public Category GetByTagsAndCreateIfNotExist(int nhomDanhMucId, string tags)
        {
            var query = _dbContext.Categories.Where(x => x.NhomID == nhomDanhMucId && x.Tags.Contains(tags));

            if (query.Count() > 0)
            {
                return query.First();
            }

            Category newCategory = new()
            {
                NhomID = nhomDanhMucId,
                Name = tags,
                Tags = tags
            };

            var entity = Add(newCategory);
            return entity;
        }
    }
}
