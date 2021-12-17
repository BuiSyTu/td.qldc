using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TD.QLDC.Library.ViewModels.Dashboard
{
    public class ChartItem
    {
        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("value")]
        public string Value { get; set; }

        [JsonProperty("value2")]
        public string Value2 { get; set; }

        [JsonProperty("color")]
        public string Color { get; set; }
    }
}
