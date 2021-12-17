using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TD.QLDC.Library.ViewModels.Dashboard
{
    public class Widget
    {
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("data")]
        public ICollection<WidgetItem> Data { get; set; }
    }
}
