using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TD.QLDC.Library.FilterModels;
using TD.QLDC.Library.Models;

namespace TD.QLDC.Library.Repositories.Interfaces
{
    public interface INhomDanhMucRepository : IGenericRepository<NhomDanhMuc>
    {
        ICollection<NhomDanhMuc> Get(NhomDanhMucFilterModel filterModel);

        int Count(NhomDanhMucFilterModel filterModel);
    }
}
