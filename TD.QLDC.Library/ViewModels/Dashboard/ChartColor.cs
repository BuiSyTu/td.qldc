using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TD.QLDC.Library.ViewModels.Dashboard
{
    public class ChartColor
    {
        public static string Random()
        {
            var colors = new List<string>
            {
                "#FF0F00",
                "#FF6600",
                "#FF9E01",
                "#FCD202",
                "#F8FF01",
                "#B0DE09",
                "#04D215",
                "#0D8ECF",
                "#0D52D1",
                "#2A0CD0",
                "#8A0CCF",
                "#CD0D74"
            };

            var length = colors.Count;
            var randomIndex = new Random().Next(length);

            return colors[randomIndex];
        }
    }
}
