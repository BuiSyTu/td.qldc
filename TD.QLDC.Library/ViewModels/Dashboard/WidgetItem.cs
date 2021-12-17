using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TD.QLDC.Library.ViewModels.Dashboard
{
    public class WidgetItem
    {
        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("value")]
        public int Value { get; set; }

        [JsonProperty("iconClass")]
        public string IconClass { get; set; }

        [JsonProperty("backgroundColor")]
        public string BackgroundColor { get; set; } = WidgetColor.Info;

        [JsonProperty("link")]
        public string Link { get; set; }

        [JsonProperty("textColor")]
        public string TextColor { get; set; } = WidgetColor.White;
    }
}
