using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TD.QLDC.Library.Models
{
   
    public class NhomDanhMuc : ModelBaseExt
    {
        private string name;
        public string Name { get { return name; } set { name = value; NotifyPropertyChanged(); } }

        public virtual List<Category> DanhMuc { get; set; }

    }
}
