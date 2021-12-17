using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TD.QLDC.Library.ViewModels
{
    public class PayLoadJWT
    {
        public int Iat { get; set; }

        public int Exp { get; set; }

        public string User { get; set; }

        public string Permissions { get; set; }
    }
}
