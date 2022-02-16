using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TD.QLDC.Library.Models;

namespace TD.QLDC.Library.Repositories.Interfaces
{
    public interface IAreaRepository : IGenericRepository<Area>
    {
        ICollection<Area> Get(
            int skip = 0,
            int top = 20,
            string q = null,
            string includes = null,
            string orderBy = null,
            string areaCode = null,
            int? type = null,
            string parentCode = null);

        int Count(
            string q = null,
            string areaCode = null,
            int? type = null,
            string parentCode = null
        );

        Area GetSingleByCode(string code);
    }
}
