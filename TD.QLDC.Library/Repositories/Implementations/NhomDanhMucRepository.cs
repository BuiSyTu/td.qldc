using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using TD.Core.Api.Mvc;
using TD.QLDC.Library.Extensions.Queryable;
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


        public int Count(
           string search = null

        )
        {
            return _dbContext.NhomDanhMucs
                .Filter(
                    !string.IsNullOrEmpty(search),
                    x => x.Name.Contains(search)
                )
                .Count();
        }

        public ICollection<NhomDanhMuc> Get(
            int skip = 0, int take = 100,
            string search = null,
            string orderBy = null,
            string includes = null
            )
        {
            return _dbContext.NhomDanhMucs
                .IncludeMany(includes)
                .Filter(
                    !string.IsNullOrEmpty(search),
                    x => x.Name.Contains(search)
                )
                .OrderByMany(orderBy)
                .Skip(skip)
                .Take(take)
                .ToList();
        }
    }
}

