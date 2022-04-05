using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TD.QLDC.Library.FilterModels
{
    public class AreaFilterModel : BaseFilterModel
    {
        public string AreaCode { get; set; } = string.Empty;
        public string ParentCode { get; set; } = string.Empty;
        public int? Type { get; set; } = null;
    }
}
