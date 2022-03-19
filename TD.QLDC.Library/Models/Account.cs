using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TD.QLDC.Library.Models
{
    public class Account
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string MD5Password { get; set; }
    }
}
