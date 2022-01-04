using System;
using System.Data.Entity;
using System.Linq;
using TD.Core.Api;
using TD.Core.Api.Mvc;
using TD.Core.Api.Mvc.Extensions;
using TD.QLDC.Library.Interfaces;
using TD.QLDC.Library.Models;

namespace TD.QLGD.Library
{
	public class EFRepository<T> : EFRepository<T, int>, IRepository<T>  where T : Entity<int>, new()
    {
        public EFRepository(QLDCDbContext context, ICoreContextAccessor ctxAccessor)
		: base(context, ctxAccessor)
        {
        }
    }
}