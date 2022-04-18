using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using TD.Core.Api.Mvc;
using TD.QLDC.Library.Common;
using TD.QLDC.Library.FilterModels;
using TD.QLDC.Library.Models;
using TD.QLDC.Library.Repositories.Interfaces;

namespace TD.QLDC.Library.Repositories.Implementations
{
    public class NhomDanhMucRepository : GenericRepository<NhomDanhMuc>, INhomDanhMucRepository
    {
        private QLDCDbContext _dbContext;

        public NhomDanhMucRepository(
            QLDCDbContext dbContext,
            ICoreContextAccessor contextAccessor
        ) : base(dbContext, contextAccessor)
        {
            _dbContext = dbContext;
        }

        public override NhomDanhMuc Add(NhomDanhMuc model)
        {
            model.FullTextSearch = CommonService.GenerateFullTextSearch(new List<string>
            {
                model.Name,
            });

            return base.Add(model);
        }

        public override void Update(NhomDanhMuc model)
        {
            model.FullTextSearch = CommonService.GenerateFullTextSearch(new List<string>
            {
                model.Name,
            });

            base.Update(model);
        }

        public int Count(NhomDanhMucFilterModel filterModel)
        {
            if (filterModel is null) filterModel = new NhomDanhMucFilterModel();

            var initQuery = _dbContext.NhomDanhMucs.AsQueryable();
            return CreateQuery(initQuery, filterModel).Count();
        }

        public ICollection<NhomDanhMuc> Get(NhomDanhMucFilterModel filterModel)
        {
            if (filterModel is null) filterModel = new NhomDanhMucFilterModel();

            var initQuery = _dbContext.NhomDanhMucs.IncludeMany(filterModel.Includes);
            return CreateQuery(initQuery, filterModel)
                .OrderByMany(filterModel.OrderBy)
                .Skip(filterModel.Skip)
                .Take(filterModel.Top)
                .ToList();
        }

        private IQueryable<NhomDanhMuc> CreateQuery(IQueryable<NhomDanhMuc> initQuery, NhomDanhMucFilterModel filterModel)
        {
            return initQuery
                .Filter(
                    !string.IsNullOrEmpty(filterModel.Q),
                    x => x.Name.Contains(filterModel.Q)
                );
        }
    }
}

