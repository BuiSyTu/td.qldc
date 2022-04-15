using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TD.QLDC.Library.FilterModels;
using TD.QLDC.Library.Models;

namespace TD.QLDC.Library.Repositories.Interfaces
{
    public interface IAreaRepository : IGenericRepository<Area>
    {
        ICollection<Area> Get(AreaFilterModel filterModel);

        int Count(AreaFilterModel filterModel);

        Area GetSingleByCode(string code, string includes = null);

        Area GetSingleByName(string name);

        ICollection<Area> GetMultipleByName(string name, string includes = null);

        ICollection<Area> GetByCodes(string codes, string includes = null);

        Dictionary<string, string> GetCurrentArea();

        Area GetSingleByTags(string tags);


        Area GetByCode(string code, string includes);
    }
}
