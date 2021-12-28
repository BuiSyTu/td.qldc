using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TD.Core.Api.Mvc;
using TD.QLDC.Library.Models;

namespace TD.QLDC.Library.Repositories
{
    public interface IAreaRepository : IGenericRepository<Area>
    {

    }

    public class AreaRepository : GenericRepository<Area>, IAreaRepository
    {
        private QLDCDbContext _dbContext;

        public AreaRepository(
            QLDCDbContext dbContext,
            ICoreContextAccessor contextAccessor
        ) : base(dbContext, contextAccessor)
        {
            _dbContext = dbContext;
        }
    }
}
