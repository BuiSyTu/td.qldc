using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TD.QLDC.Library.FilterModels;
using TD.QLDC.Library.Models;

namespace TD.QLDC.Library.Repositories.Interfaces
{
    public interface ICategoryRepository : IGenericRepository<Category>
    {
        ICollection<Category> Get(CategoryFilterModel filterMoel);

        int Count(CategoryFilterModel filterModel);

        Category GetByNameAndCreateIfNotExist(int nhomDanhMucId, string name);

        Category GetByTagsAndCreateIfNotExist(int nhomDanhMucId, string tags);

        Category GetSingleByTags(string tags);
    }
}
