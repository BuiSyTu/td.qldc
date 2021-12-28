using System.Collections.Generic;
using TD.Core.Api.Common;

namespace TD.QLDC.Library.Repositories
{
    public interface IGenericRepository<T>
    {
        T Add(T model);
        int Count();
        T GetById(int id);
        ICollection<T> Get(
            int skip = 0,
            int take = 100,
            string search = null,
            bool searchIsQuery = false,
            ICollection<string> orderBy = null,
            IEnumerable<string> viewFields = null);
        void Update(T model);
        ICollection<T> GetAll();
        void Delete(T entity);
    }
}
