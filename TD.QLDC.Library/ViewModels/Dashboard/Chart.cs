using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TD.QLDC.Library.ViewModels.Dashboard
{
    public class Chart
    {
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("data")]
        public ICollection<ChartItem> Data { get; set; }
    }
}
