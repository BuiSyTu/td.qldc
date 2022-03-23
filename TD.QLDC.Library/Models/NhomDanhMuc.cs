using Newtonsoft.Json;
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
        private string fullTextSearch;
        [JsonIgnore]
        public string FullTextSearch { get { return fullTextSearch; } set { fullTextSearch = value; NotifyPropertyChanged(); } }

        private string name;
        public string Name { get { return name; } set { name = value; NotifyPropertyChanged(); } }

        public virtual List<Category> DanhMuc { get; set; }
    }

    public class NhomDanhMucId
    {
        public const int DanToc = 1;
        public const int QuocTich = 2;
        public const int TonGiao = 3;
        public const int DoiTuong = 4;
        public const int LoaiDoiTuong = 5;
        public const int TinhTrangCuTru = 6;
        public const int TinhTrangHonNhan = 7;
        public const int QuanHeVoiChuHo = 8;
        public const int TrinhDoVanHoa = 9;
        public const int TrinhDoChuyenMon = 10;
        public const int LoaiHoGiaDinh = 11;
    }
}
