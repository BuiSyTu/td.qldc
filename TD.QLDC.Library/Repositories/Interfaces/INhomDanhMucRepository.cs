using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TD.QLDC.Library.Models;

namespace TD.QLDC.Library.Repositories.Interfaces
{
    public interface INhomDanhMucRepository : IGenericRepository<NhomDanhMuc>
    {
        ICollection<NhomDanhMuc> Get(
            int skip = 0,
            int take = 100,
            string search = null,
            string orderBy = null,
            string includes = null);
        int Count(string search = null);
    }
}
