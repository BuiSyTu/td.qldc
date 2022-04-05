using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TD.QLDC.Library.FilterModels
{
    public class BaseFilterModel
    {
        public int Skip { get; set; } = 0;
        public int Top { get; set; } = 20;
        public string Q { get; set; } = string.Empty;
        public string Includes { get; set; } = string.Empty;
        public string OrderBy { get; set; } = string.Empty;
        public bool Count { get; set; } = false;
        public bool? Active { get; set; } = null;
    }
}
