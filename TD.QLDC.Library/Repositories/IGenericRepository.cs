using System.Collections.Generic;
using TD.Core.Api.Common;

namespace TD.QLDC.Library.Repositories
{
    public interface IGenericRepository<T>: IGenericController<T, int>
    {
        IEnumerable<T> AddRange(IEnumerable<T> entities);

        List<T> Get(
            int skip = 0, int take = 100,
            string search = null,
            ICollection<string> orderBy = null, ICollection<string> include = null, string field = null, object value = null);

        int CountQuery(string search = null, string field = null, object value = null);
        
        IEnumerable<T> Export();

        IEnumerable<T> Import(IEnumerable<T> entities);
    }
}
